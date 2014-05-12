using System;
using System.Data;
using System.Data.OleDb;

namespace Business
{
	/// <summary>Class responsible for interacting with the SubSystems table.</summary>
	public class CSubSystem : CBusiness
	{
		#region Member variables
		#endregion
		#region Properties
		#endregion
		#region Constructor/Destructor
		public CSubSystem() : base() {}
		public CSubSystem(string pConnectionString) : base(pConnectionString) {}
		public CSubSystem(OleDbConnection pConnection) : base(pConnection) {}
		#endregion
		#region Public methods
		public override void Get()
		{
			// Not needed/implemented
		}

		public override void Get(int pSystemID)
		{
			m_oData.SetupCommand(String.Format("select * from SubSystems where system_id = {0} order by subsystem_desc", pSystemID));
			m_oData.ExecuteWithRecordset();
		}

		/// <summary>Saves the passed System description to the passed System ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pID">ID of the System to update (if it exists).</param>
		/// <param name="pDescription">Description to set.</param>
		/// <returns>ID of the modified/created row.</returns>
		public int Save(int pSystemID, int pSubSystemID, string pDescription)
		{
			int iID = (pSubSystemID > 0) ? pSubSystemID : 1;
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("select * from SubSystems where system_id = {0}", pSystemID), this.m_oDBConn.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.m_oDBConn.ConnectionString))
				{
					oConn.Open();
					DataSet oDS = new DataSet("SubSystems");
					oDA.Fill(oDS);

					if((oDS.Tables[0].Rows.Count > 0) && (pSubSystemID > 0))
					{
						// Should only be one row returned, but go ahead and update all found.
						foreach(DataRow oRow in oDS.Tables[0].Rows)
						{
							if((int)oRow["subsystem_id"] == pSubSystemID)
							{
								oRow.BeginEdit();
								oRow["subsystem_desc"] = pDescription;
								oRow["date_last_modified"]	= DateTime.Now;
								oRow.EndEdit();
							}
						}
					}
					else
					{
						// Get the next available SubSystem ID.
						iID = this.DetermineNextID();
						DataRow oRow								= oDS.Tables[0].NewRow();
						oRow["system_id"]						= pSystemID;
						oRow["subsystem_id"]				= iID;
						oRow["subsystem_desc"]			= pDescription;
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

		/// <summary>Determine the next available SubSystem ID.</summary>
		/// <returns></returns>
		public override int DetermineNextID()
		{
			this.DataObject.SetupCommand("select max(subsystem_id)+1 as next_subsystem_id from SubSystems");
			return this.GetNextID();
		}

		#endregion
	}
}