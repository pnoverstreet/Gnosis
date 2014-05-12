using System;
using System.Text;					// For StringBuilder
using System.Data;					// For DataTable
using System.Data.OleDb;		// For OleDb stuff

namespace Business
{
	/// <summary>Base class for KnowBase business classes.</summary>
	public class CBusiness
	{
		#region Member variables
		protected int										m_iIndex;
//		protected string								m_sConnectionString;
		protected OleDbConnection		m_oDBConn;
		protected DataSet						m_oData;
		#endregion
		#region Properties
		public CDatabaseOLE DataObject
		{
			get { return this.m_oData; }
		}
		public DataTable Data
		{
			get { return m_oData.GetData(); }
		}
//		public string ConnectionString
//		{
//			get { return m_sConnectionString; }
//			set { this.m_sConnectionString = value; }
//		}
		#endregion
		public CBusiness()
		{
			this.m_iIndex = 0;	// Setup an index into our data rows
			this.m_oData = new CDatabaseOLE();
		}
		public CBusiness(string pConnectionString) : this()
		{
			//this.m_sConnectionString = pConnectionString;
			//oDBConn = new OleDbConnection(pConnectionString);
//			this.m_oData.SetConnection(pConnectionString);
			this.m_oData.ConnectionString = pConnectionString;
		}
		public CBusiness(OleDbConnection pConnection)
		{
			this.m_oDBConn = pConnection;
			this.m_oData = new CDatabaseOLE(pConnection.ConnectionString);
		}
		#region Public methods
//		public void SetConnection(string pDBConnection)
//		{
//			// Note: This connection is just here for convenience to keep from having to pass the connection string all over the place.
//			// Connection should be performed according to Microsoft "Best Practice" with a "using" statement wrapping the database functionality.
//			m_oDBConn = new OleDbConnection(pDBConnection);
//			m_oData = new CDatabaseOLE(pDBConnection);
//		}
//		public void SetConnection(OleDbConnection pDBConnection)
//		{
//			// Note: This connection is just here for convenience to keep from having to pass the connection string all over the place.
//			// Connection should be performed according to Microsoft "Best Practice" with a "using" statement wrapping the database functionality.
//			m_oDBConn = pDBConnection;
//		}
		virtual public void Initialize()
		{
		}
		virtual public void Get()
		{
		}

		virtual public void Get(int pID)
		{
		}

		/// <summary>Not implemented here.  Instead, each inheritor must implement separately since they contain different fields, etc.</summary>
		/// <param name="pID"></param>
		/// <param name="pDescription"></param>
		/// <returns></returns>
//		virtual public bool Save(int pID, string pDescription)
//		{
//			return false;
//		}

		/// <summary>Delete method.</summary>
		virtual public void Delete()
		{
			// Not implemented here
		}

		/// <summary>Get the next available ID for the current object.</summary>
		virtual public int DetermineNextID()
		{
			// Get the next available Solutions ID
			//this.DataObject.SetupCommand("select max(solution_id)+1 as next_id from Solutions");
			return this.GetNextID();
		}

		/// <summary>Get the next available Sequence number for the current ID.</summary>
		virtual public int DetermineNextSequence(int pID)
		{
			//this.DataObject.SetupCommand("select max(solution_seq)+1 as next_seq from Solutions where issue_id = " + pIssueID);
			return this.GetNextSequence(pID);
		}
		#endregion
		#region Private methods
		/// <summary>Get the next available ID for the current object.</summary>
		/// <returns>Integer representing the next available ID.</returns>
		/// <remarks>Prepare the SQL Command object within this object first.
		/// Make sure to specify the returned column name as "next_id".
		/// </remarks>
		protected int GetNextID()
		{
			int iID = 1;

			using(DataSet oDS = new DataSet())
			using(OleDbDataAdapter oDA = new OleDbDataAdapter(this.DataObject.Command)) //String.Format("select max(solution_seq)+1 as next_solution_seq from Solutions where issue_id = {0}", pIssueID), this.DataObject.ConnectionString))
			using(OleDbConnection oConn = new OleDbConnection(this.DataObject.ConnectionString))
			{
				this.DataObject.Command.Connection = oConn;
				oDA.Fill(oDS);
				DataRow oRow = oDS.Tables[0].Rows[0];
				iID = ((oDS.Tables[0].Rows.Count > 0) && (!oRow.IsNull("next_id"))) ? (int)oRow["next_id"] : 1;
			}
			return iID;
		}

		/// <summary>Get the next available sequence number for a given ID.</summary>
		/// <param name="pIssueID">Integer representing the ID to which the sequence number should apply.</param>
		/// <returns>Integer representing the next available sequence number.</returns>
		/// <remarks>Prepare the SQL Command object within this object first.
		/// Make sure to specify the returned column name as "next_seq".
		/// </remarks>
		protected int GetNextSequence(int pParentID)
		{
			int iSeqNum = 1;

			using(DataSet oDS = new DataSet())
			using(OleDbDataAdapter oDA = new OleDbDataAdapter(this.DataObject.Command))	//String.Format("select max(solution_seq)+1 as next_solution_seq from Solutions where issue_id = {0}", pIssueID), this.DataObject.ConnectionString))
			using(OleDbConnection oConn = new OleDbConnection(this.DataObject.ConnectionString))
			{
				this.DataObject.Command.Connection = oConn;
				oDA.Fill(oDS);
				DataRow oRow = oDS.Tables[0].Rows[0];
				iSeqNum = ((oDS.Tables[0].Rows.Count > 0) && (!oRow.IsNull("next_seq"))) ? (int)oRow["next_seq"] : 1;
			}
			return iSeqNum;
		}
		#endregion
	}
}
