using System;
using System.Data;
using System.Data.OleDb;

namespace Business
{
	/// <summary>Class responsible for interacting with the Solutions table.</summary>
	public class CSolution : CBusiness
	{
		#region Constructor/Destructor
		public CSolution() : base() {}
		public CSolution(string pConnectionString) : base(pConnectionString) {}
		public CSolution(OleDbConnection pConnection) : base(pConnection) {}
		#endregion
		#region Public methods
		public override void Get()
		{
			// Not implemented
//			m_oData.SetupCommand("select * from Solutions order by solution_desc");
//			m_oData.ExecuteWithRecordset();
		}
		public override void Get(int pID)
		{
			m_oData.SetupCommand(String.Format("select * from Solutions where issue_id = {0} order by solution_seq", pID));
			m_oData.ExecuteWithRecordset();
		}
		/// <summary>Saves the passed System description to the passed System ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pIssueID">ID of the Issue the solution applies to.</param>
		/// <param name="pDescription">Description of the solution.</param>
		/// <returns>ID of the modified/created solution row.</returns>
		public int Save(int pIssueID, int pSolutionID, string pDescription)
		{
			int iID = (pSolutionID > 0) ? pSolutionID : 1;
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("Select * from Solutions where issue_id = {0} and solution_id = {1} order by solution_seq", pIssueID, pSolutionID), this.DataObject.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.DataObject.ConnectionString))
				{
					// Get the list of previously saved Solutions to the current Issue.
					oConn.Open();
					DataSet oDS = new DataSet("Solutions");
					oDA.Fill(oDS);

					// If we found any...And we're updating an existing Solution...
					if(oDS.Tables[0].Rows.Count > 0)
					{
						DataRow oRow = oDS.Tables[0].Rows[0];

						oRow.BeginEdit();
						oRow["solution_desc"]				= pDescription;
						oRow["date_last_modified"]	= DateTime.Now;
						oRow.EndEdit();
					}
					else
					{
						// Determine the next available Solution ID.
						iID = this.DetermineNextID();
						DataRow oRow								= oDS.Tables[0].NewRow();
						oRow["issue_id"]						= pIssueID;
						oRow["solution_id"]					= iID;
						oRow["solution_desc"]				= pDescription;
						oRow["solution_seq"]				= this.DetermineNextSequence(pIssueID);
						oRow["date_created"]				= DateTime.Now;
						oRow["date_last_modified"]	= DateTime.Now;
						
						oDS.Tables[0].Rows.Add(oRow);
					}
						
					oDA.Update(oDS);
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save new Solution!\nError: " + e.Message);
			}
			return iID;
		}

		/// <summary>WARNING: THIS METHOD DELETES ALL SOLUTIONS ASSOCIATED WITH THE SPECIFIED ISSUE ID.</summary>
		/// <param name="pIssueID">ID of the Issue the solutions apply to.</param>
		public void Delete(int pIssueID)
		{
			try
			{
				this.DataObject.SetupCommand(String.Format("delete from Solutions where issue_id = {0}", pIssueID));
				this.DataObject.ExecuteWithRecordset();
			}
			catch(Exception e)
			{
				throw new Exception(String.Format("Failed to delete Solutions for Issue ID {0}!\nError: {1}", pIssueID, e.Message));
			}
		}

		/// <summary>Delete the specified Solution from the specified Issue.</summary>
		/// <param name="pIssueID">ID of the Issue the solution applies to.</param>
		/// <param name="pSolutionID">ID of the Solution to delete.</param>
		/// <returns>ID of the modified/created solution row.</returns>
		public void Delete(int pIssueID, int pSolutionID)
		{
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("Select * from Solutions where issue_id = {0} and solution_id = {1} order by solution_seq", pIssueID, pSolutionID), this.DataObject.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.DataObject.ConnectionString))
				{
					// Get the list of previously saved Solutions to the current Issue.
					oConn.Open();
					DataSet oDS = new DataSet("Solutions");
					oDA.Fill(oDS);

					// If we found any...And we're updating an existing Solution...
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
				throw new Exception("Unable to save new Issue Solution!\nError: " + e.Message);
			}
		}

		/// <summary>Get the next available ID for a new Solution.</summary>
		public override int DetermineNextID()
		{
			// Get the next available Solutions ID
			this.DataObject.SetupCommand("select max(solution_id)+1 as next_id from Solutions");
			return this.GetNextID();
		}

		/// <summary>Get the next available Solution Sequence number for the current Issue.</summary>
		public override int DetermineNextSequence(int pIssueID)
		{
			this.DataObject.SetupCommand("select max(solution_seq)+1 as next_seq from Solutions where issue_id = " + pIssueID);
			return this.GetNextSequence(pIssueID);
		}
		#endregion
		#region Private methods
		#endregion
	}
}
