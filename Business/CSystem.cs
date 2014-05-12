using System;
using System.Data;
using System.Data.OleDb;

namespace Business
{
	/// <summary>Class representing software/hardware systems.</summary>
	public class CSystem : CBusiness
	{
		#region Constructor/Destructor
		public CSystem() : base() {}
		public CSystem(string pConnectionString) : base(pConnectionString) {}
		public CSystem(OleDbConnection pConnection) : base(pConnection) {}
		#endregion
		#region Public methods
		public override void Get()
		{
			m_oData.SetupCommand("select * from Systems order by system_desc");
			m_oData.ExecuteWithRecordset();
		}
		public override void Get(int pID)
		{
			m_oData.SetupCommand(String.Format("select * from systems where system_id = {0}", pID));
			m_oData.ExecuteWithRecordset();
		}
		/// <summary>Saves the passed System description to the passed System ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pID">ID of the System to update (if it exists).</param>
		/// <param name="pDescription">Description to set.</param>
		/// <returns>ID of the modified/created row.</returns>
		public int Save(int pSystemID, string pDescription)
		{
			int iID = (pSystemID > 0) ? pSystemID : 1;
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("select * from Systems where system_id = {0}", pSystemID), this.m_oDBConn.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.m_oDBConn.ConnectionString))
				{
					oConn.Open();
					DataSet oDS = new DataSet("Systems");
					oDA.Fill(oDS);

					if((oDS.Tables[0].Rows.Count > 0) && (pSystemID > 0))
					{
						// Should only be one row returned, but go ahead and update all found.
						foreach(DataRow oRow in oDS.Tables[0].Rows)
						{
							if((int)oRow["system_id"] == pSystemID)
							{
								oRow.BeginEdit();
								oRow["system_desc"]					= pDescription;
								oRow["date_last_modified"]	= DateTime.Now;
								oRow.EndEdit();
							}
						}
					}
					else
					{
						// Determine the next available System ID.
						iID = this.DetermineNextID();
						DataRow oRow								= oDS.Tables[0].NewRow();
						oRow["system_id"]						= iID;
						oRow["system_desc"]					= pDescription;
						oRow["date_created"]				= DateTime.Now;
						oRow["date_last_modified"]	= DateTime.Now;

						oDS.Tables[0].Rows.Add(oRow);
					}

					oDA.Update(oDS);
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save new System!\nError: " + e.Message);
			}
			return iID;
		}

		/// <summary>Determine the next available System ID.</summary>
		/// <returns>Integer representing the next available System ID.</returns>
		public override int DetermineNextID()
		{
			this.DataObject.SetupCommand("select max(system_id)+1 as next_system_id from Systems");
			return this.GetNextID();
		}

		#endregion
		#region Private methods
		#endregion
	}
}
