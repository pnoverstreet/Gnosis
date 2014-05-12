// Items table
//		item_id							integer,
//		item_desc						varchar2(512),
//		item_creation_date	datetime,
//		item_type_id				integer,
//		item_info						varchar2(512)

using System;
using System.Text;					// For StringBuilder
using System.Data;					// For DataTable
using System.Data.OleDb;		// For OleDb objects.
using Data;

namespace Business
{
	/// <summary>Business class for handling Items</summary>
	public class CIssue : CBusiness
	{
		#region Member variables
		int					m_iIndex;
		// Objects representing data related to the Issue that is not stored within the Issues table.
		CIssueCause	m_oCause;
		CSolution		m_oSolution;
		#endregion
		#region Properties
		public int IssueID
		{
			get { return (this.Data.Rows.Count > 0) ? (int)this.Data.Rows[0]["issue_id"] : -1; }
		}
		public CIssueCause Causes
		{
			get { return this.m_oCause; }
			set { this.m_oCause = value; }
		}
		public CSolution Solutions
		{
			get { return this.m_oSolution; }
			set { this.m_oSolution = value; }
		}
		#endregion
		#region Constructor/Destructor
		public CIssue() : base() {}
		public CIssue(string pConnectionString) : base(pConnectionString) {}
		public CIssue(OleDbConnection pConnection) : base(pConnection) {}
		#endregion
		#region Public methods
		public override void Initialize()
		{
			this.m_oCause			= new CIssueCause();
			this.m_oSolution	= new CSolution();
		}

		/// <summary>Get a list of all of the IssueIds from the Issues table.</summary>
		private void GetList()
		{
			this.DataObject.SetupCommand("select issue_id from Issues order by issue_id");
			this.DataObject.ExecuteWithRecordset();
		}

//		/// <summary>Get an Issue row of data.</summary>
//		public override void Get()
//		{
//			StringBuilder stbSQL = new StringBuilder();
//			stbSQL.Append("SELECT Issues.issue_id, Issues.issue_desc, Issues.issue_type_id, Issues.system_id, Issues.subsystem_id, Issues.date_created, Issues.date_last_modified, Issues.issue_contact, Issues.issue_solved, IssueTypes.issue_type_desc, Solutions.solution_desc, SubSystems.subsystem_desc, Systems.system_desc, Contacts.contact_last_name ");
//			stbSQL.Append("FROM Contacts RIGHT JOIN (Systems RIGHT JOIN (SubSystems RIGHT JOIN (IssueTypes RIGHT JOIN Issues ON IssueTypes.issue_type_id=Issues.issue_type_id) ON SubSystems.subsystem_id=Issues.subsystem_id) ON Systems.system_id=Issues.system_id) ON Contacts.contact_id=Issues.contact_id ");
//			stbSQL.Append("ORDER BY Issues.issue_desc;");
//			m_oData.SetupCommand(stbSQL.ToString());
//			m_oData.ExecuteWithRecordset();
//		}
		public override void Get(int pID)
		{
			StringBuilder stbSQL = new StringBuilder();
			stbSQL.Append("SELECT Issues.issue_id, Issues.issue_desc, Issues.issue_type_id, Issues.system_id, Issues.subsystem_id, Issues.date_created, Issues.date_last_modified, Issues.issue_contact, Issues.issue_solved, IssueTypes.issue_type_desc, SubSystems.subsystem_desc, Systems.system_desc, (Contacts.contact_name_first+' '+Contacts.contact_name_last) as contact_name ");
			stbSQL.Append("FROM Contacts RIGHT JOIN (Systems RIGHT JOIN (SubSystems RIGHT JOIN (IssueTypes RIGHT JOIN Issues ON IssueTypes.issue_type_id=Issues.issue_type_id) ON SubSystems.subsystem_id=Issues.subsystem_id) ON Systems.system_id=Issues.system_id) on Contacts.contact_id=Issues.contact_id ");
			stbSQL.Append(String.Format("WHERE Issues.issue_id = {0} ", pID));
			m_oData.SetupCommand(stbSQL.ToString());
			m_oData.ExecuteWithRecordset();
			this.GetCause();
			this.GetSolution();
		}

		/// <summary>Saves the passed Issue to the passed ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pID">Integer representing the ID of the Issue to update (if it exists). Passing this in as -1 indicates an explicit Insert.</param>
		/// <param name="pDescription">String representing the Description of the issue.</param>
		/// <param name="pIssueTypeID">Integer representing the Issue Type ID</param>
		/// <param name="pSystemID">System ID</param>
		/// <param name="pSubSystemID">SubSystem ID</param>
		/// <param name="pContact">Contact ID</param>
		/// <param name="pSolved">Boolean representing whether or not the issue is solved.</param>
		/// <param name="pSolutionID"></param>
		/// <returns>ID of the modified/created row.</returns>
		public int Save(CIssueItem pData)
		{
			int iID = 0;
			if(this.Data != null)
				iID = (this.m_oData.RecordSet.Rows.Count > 0) ? (int)this.m_oData.RecordSet.Rows[0]["issue_id"] : 0;
			try
			{
				using(DataSet oDS							= new DataSet("Issue"))
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("select * from Issues where issue_id = {0}", iID), this.DataObject.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.DataObject.ConnectionString))
				{
					//oConn.Open();
					//DataSet oDS = new DataSet("Issue");
					oDA.Fill(oDS);

					// Are we updating?
					if(oDS.Tables[0].Rows.Count > 0)
					{
						// Should only be one row returned, but go ahead and update all found.
						foreach(DataRow oRow in oDS.Tables[0].Rows)
						{
							if((int)oRow["issue_id"] == iID)
							{
								oRow.BeginEdit();
								oRow["issue_desc"]					= pData.IssueDescription;
								if(pData.IssueTypeID > 0)	oRow["issue_type_id"]	= pData.IssueTypeID;
								if(pData.SystemID > 0)		oRow["system_id"]			= pData.SystemID;
								if(pData.SubSystemID > 0)	oRow["subsystem_id"]	= pData.SubSystemID;
								if(pData.ContactID > 0)		oRow["contact_id"]		= pData.ContactID;
								oRow["issue_solved"]				= pData.IsSolved;
								oRow["date_last_modified"]	= DateTime.Now;
								oRow.EndEdit();
							}
						}
					}
					else	// Or Inserting
					{
						// Determine the next available Issue ID.
						pData.IssueID = this.DetermineNextID();

						DataRow oRow								= oDS.Tables[0].NewRow();
						oRow["issue_id"]						= pData.IssueID;
						oRow["issue_desc"]					= pData.IssueDescription;
						if(pData.IssueTypeID > 0)		oRow["issue_type_id"]	= pData.IssueTypeID;
						if(pData.SystemID > 0)			oRow["system_id"]			= pData.SystemID;
						if(pData.SubSystemID > 0)		oRow["subsystem_id"]	= pData.SubSystemID;
						if(pData.ContactID > 0)			oRow["contact_id"]		= pData.ContactID;
						oRow["issue_solved"]				= pData.IsSolved;
						oRow["date_created"]				= DateTime.Now;
						oRow["date_last_modified"]	= DateTime.Now;

						oDS.Tables[0].Rows.Add(oRow);
					}

					oDA.Update(oDS);
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save Issue!\nError: " + e.Message);
			}
			return pData.IssueID;
		}

		public override void Delete()
		{
			this.Causes.Delete(this.IssueID);
			this.Solutions.Delete(this.IssueID);
			this.DataObject.SetupCommand(String.Format("delete from Issues where issue_id = {0}", this.IssueID));
			this.DataObject.ExecuteWithRecordset();
		}

		/// <summary>Determine the next available Issue ID.</summary>
		/// <returns>Integer representing the next available Issue ID.</returns>
		public override int DetermineNextID()
		{
			this.DataObject.SetupCommand("select max(issue_id)+1 as next_id from Issues");
			return this.GetNextID();
		}

		/// <summary>Retrieve the cause(s) for data related to this issue that resides in other tables.</summary>
		public void GetCause()
		{
			// Get the Issue cause(s) and add as another table of the local DataSet
			m_oCause	= new CIssueCause(this.DataObject.ConnectionString);
			m_oCause.Get(this.IssueID);
		}

		/// <summary>Retrieve the cause(s) for data related to this issue that resides in other tables.</summary>
		public void GetSolution()
		{
			// Get the Issue solution(s) and add as another table of the local DataSet
			m_oSolution			= new CSolution(this.DataObject.ConnectionString);
			m_oSolution.Get(this.IssueID);
		}
		#endregion
		#region Private methods
		#endregion
	}
}
