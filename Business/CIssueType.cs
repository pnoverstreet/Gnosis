// IssueTypes table
//		issue_type_id				integer,
//		issue_type_desc			varchar2(64)
using System;
using System.Data;
using System.Data.OleDb;

namespace Business
{
	/// <summary>Business class which handles represents Item_Types.</summary>
	public class CIssueType : CBusiness
	{
		#region Member variables
		#endregion
		#region Properties
		#endregion
		#region Constructor/Destructor
		public CIssueType() : base() {}
		public CIssueType(string pConnectionString) : base(pConnectionString) {}
		public CIssueType(OleDbConnection pConnection) : base(pConnection) {}
		#endregion
		#region Public methods
		public override void Get()
		{
			m_oData.SetupCommand("select * from IssueTypes order by issue_type_desc");
			m_oData.ExecuteWithRecordset();
		}
		public override void Get(int pID)
		{
			m_oData.SetupCommand(String.Format("select * from IssueTypes where issue_type_id = {0}", pID));
			m_oData.ExecuteWithRecordset();
		}

		/// <summary>Saves the passed IssueType description to the passed IssueType ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pIssueTypeID">ID of the IssueType to update (if it exists).  -1 indicates an explicit Insert.</param>
		/// <param name="pDescription">Description to set.</param>
		/// <returns>ID of the modified/created row.</returns>
		public int Save(int pIssueTypeID, string pDescription)
		{
			int iID = 0;
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("select * from IssueTypes where issue_type_id = {0}", pIssueTypeID), this.m_oDBConn.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.m_oDBConn.ConnectionString))
				{
					oConn.Open();
					DataSet oDS = new DataSet("IssueTypes");
					oDA.Fill(oDS);

					if((oDS.Tables[0].Rows.Count > 0) && (pIssueTypeID > 0))
					{
						// Should only be one row returned, but go ahead and update all found.
						foreach(DataRow oRow in oDS.Tables[0].Rows)
						{
							if((int)oRow["issue_type_id"] == pIssueTypeID)
							{
								oRow.BeginEdit();
								oRow["issue_type_desc"]			= pDescription;
								oRow["date_last_modified"]	= DateTime.Now;
								oRow.EndEdit();
							}
						}
					}
					else
					{
						// Determine the next ID number
						using(DataSet oDS2 = new DataSet())
						using(OleDbDataAdapter oDA2 = new OleDbDataAdapter("select max(issue_type_id)+1 as issue_type_id from IssueTypes", this.m_oDBConn.ConnectionString))
						using(OleDbConnection oConn2 = new OleDbConnection(this.m_oDBConn.ConnectionString))
						{
							oDA2.Fill(oDS2);
							iID = (oDS2.Tables[0].Rows.Count > 0) ? (int)oDS2.Tables[0].Rows[0]["issue_type_id"] : 1;
						}

						DataRow oRow								= oDS.Tables[0].NewRow();
						oRow["issue_type_id"]				= iID;
						oRow["issue_type_desc"]			= pDescription;
						oRow["date_created"]				= DateTime.Now;
						oRow["date_last_modified"]	= DateTime.Now;

						oDS.Tables[0].Rows.Add(oRow);
					}

					oDA.Update(oDS);
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save new IssueType!\nError: " + e.Message);
			}
			return iID;
		}
		#endregion
		#region Private methods
		#endregion
	}
}
