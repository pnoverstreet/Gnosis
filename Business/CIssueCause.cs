using System;
using System.Data;
using System.Data.OleDb;

namespace Business
{
	/// <summary>Class representing Issue Cause(s).</summary>
	public class CIssueCause : CBusiness
	{
		#region Constructor/Destructor
		public CIssueCause() : base() {}
		public CIssueCause(string pConnectionString) : base(pConnectionString) {}
		public CIssueCause(OleDbConnection pConnection) : base(pConnection.ConnectionString) {}
		#endregion
		#region Public methods
		public override void Get()
		{
			// Not implemented
			//			m_oData.SetupCommand("select * from Causes order by cause_desc");
			//			m_oData.ExecuteWithRecordset();
		}
		public override void Get(int pID)
		{
			m_oData.SetupCommand(String.Format("select * from Causes where issue_id = {0} order by cause_seq", pID));
			m_oData.ExecuteWithRecordset();
		}
		/// <summary>Saves the passed System description to the passed System ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pIssueID">ID of the Issue the cause applies to.</param>
		/// <param name="pDescription">Description of the cause.</param>
		/// <returns>ID of the modified/created cause row.</returns>
		public int Save(int pIssueID, int pCauseID, string pDescription)
		{
			int iID = (pCauseID > 0) ? pCauseID : 1;
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("Select * from Causes where issue_id = {0} and cause_id = {1} order by cause_seq", pIssueID, pCauseID), this.DataObject.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.DataObject.ConnectionString))
				{
					// Get the list of previously saved Causes to the current Issue.
					oConn.Open();
					DataSet oDS = new DataSet("Causes");
					oDA.Fill(oDS);

					// If we found any...And we're updating an existing Cause...
					if(oDS.Tables[0].Rows.Count > 0)
					{
						// Should only be one row returned, but go ahead and update all found.
						DataRow oRow = oDS.Tables[0].Rows[0];

						oRow.BeginEdit();
						oRow["cause_desc"]					= pDescription;
						oRow["date_last_modified"]	= DateTime.Now;
						oRow.EndEdit();
					}
					else
					{
						// Determine the next available Cause ID.
						iID = this.DetermineNextID();
						
						DataRow oRow								= oDS.Tables[0].NewRow();

						oRow["issue_id"]						= pIssueID;
						oRow["cause_id"]						= iID;
						oRow["cause_desc"]					= pDescription;
						oRow["cause_seq"]						= this.DetermineNextSequence(pIssueID);
						oRow["date_created"]				= DateTime.Now;
						oRow["date_last_modified"]	= DateTime.Now;
						
						oDS.Tables[0].Rows.Add(oRow);
					}
						
					oDA.Update(oDS);
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save new Issue Cause!\nError: " + e.Message);
			}
			return iID;
		}

		/// <summary>WARNING: THIS METHOD DELETES ALL CAUSES ASSOCIATED WITH THE SPECIFIED ISSUE ID.</summary>
		/// <param name="pIssueID">ID of the Issue the Causes apply to.</param>
		public void Delete(int pIssueID)
		{
			try
			{
				this.DataObject.SetupCommand(String.Format("delete from Causes where issue_id = {0}", pIssueID));
				this.DataObject.ExecuteWithRecordset();
			}
			catch(Exception e)
			{
				throw new Exception(String.Format("Failed to delete Causes for Issue ID {0}!\nError: {1}", pIssueID, e.Message));
			}
		}

		/// <summary>Delete the specified Cause from the specified Issue.</summary>
		/// <param name="pIssueID">ID of the Issue the cause applies to.</param>
		/// <param name="pCauseID">ID of the Cause to delete.</param>
		/// <returns>ID of the modified/created cause row.</returns>
		public void Delete(int pIssueID, int pCauseID)
		{
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("Select * from Causes where issue_id = {0} and cause_id = {1} order by cause_seq", pIssueID, pCauseID), this.DataObject.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.DataObject.ConnectionString))
				{
					// Get the list of previously saved Causes to the current Issue.
					oConn.Open();
					DataSet oDS = new DataSet("Causes");
					oDA.Fill(oDS);

					// If we found any...And we're updating an existing Cause...
					if(oDS.Tables[0].Rows.Count > 0)
					{
						DataRow oRow = oDS.Tables[0].Rows[0];
						oRow.Delete();
						oDA.Update(oDS);
					}
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save new Issue Cause!\nError: " + e.Message);
			}
		}

		/// <summary>Get the next available ID for a new Issue Cause.</summary>
		/// <returns>Integer representing the next unused ID number.</returns>
		public override int DetermineNextID()
		{
			// Determine the next ID number
			this.DataObject.SetupCommand("select max(cause_id)+1 as next_id from Causes");
			return this.GetNextID();
		}

		/// <summary>Get the next available sequence for the Issue Cause.</summary>
		/// <param name="pIssueID">Integer representing the Issue being modified.</param>
		/// <returns>Integer representing the next available sequence number.</returns>
		public override int DetermineNextSequence(int pIssueID)
		{
			this.DataObject.SetupCommand("select max(cause_seq)+1 as next_seq from Causes where issue_id = " + pIssueID);
			return this.GetNextSequence(pIssueID);
		}
		#endregion
		#region Private methods
		#endregion
	}
}
