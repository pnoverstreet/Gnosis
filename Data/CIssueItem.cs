using System;

namespace Data
{
	/// <summary>Class representing an Issue row.</summary>
	public class CIssueItem
	{
		#region Member variables
		private bool		m_bIsSolved;
		private int			m_iIssueID,
										m_iIssueTypeID,
										m_iSystemID,
										m_iSubSystemID,
										m_iContactID;
		private string	m_sIssueDescription;
		#endregion
		#region Properties
		/// <summary>Property: Boolean indicating whether or not this issue has been solved.</summary>
		public bool IsSolved
		{
			get { return m_bIsSolved; }
			set { m_bIsSolved = value; }
		}
		/// <summary>Property: Integer representing the current Issue ID.</summary>
		public int IssueID
		{
			get { return m_iIssueID; }
			set { m_iIssueID = value; }
		}
		/// <summary>Property: Integer representing the Issue Type ID for the current Issue.</summary>
		public int IssueTypeID
		{
			get { return m_iIssueTypeID; }
			set { m_iIssueTypeID = value; }
		}
		/// <summary>Property: Integer representing the System ID for the current Issue.</summary>
		public int SystemID
		{
			get { return m_iSystemID; }
			set { m_iSystemID = value; }
		}
		/// <summary>Property: Integer representing the SubSystem ID for the current Issue and System.</summary>
		public int SubSystemID
		{
			get { return m_iSubSystemID; }
			set { m_iSubSystemID = value; }
		}
		/// <summary>Property: Integer representing the Contact ID for the current Issue.</summary>
		public int ContactID
		{
			get { return m_iContactID; }
			set { m_iContactID = value; }
		}
		/// <summary>Property: String representing the Description of the current Issue.</summary>
		public string IssueDescription
		{
			get { return m_sIssueDescription; }
			set { m_sIssueDescription = value; }
		}
		#endregion
		#region Constructor/Destructor
		public CIssueItem()
		{
		}
		public CIssueItem(int pIssueID, int pIssueTypeID, int pSystemID, int pSubSystemID, int pContactID, bool pSolved, string pIssueDescription)
		{
			m_bIsSolved					= pSolved;
			m_iIssueID					= pIssueID;
			m_iIssueTypeID			= pIssueTypeID;
			m_iSystemID					= pSystemID;
			m_iSubSystemID			= pSubSystemID;
			m_iContactID				= pContactID;
			m_sIssueDescription = pIssueDescription;
		}
		#endregion
		#region Public methods
		#endregion
		#region Private methods
		#endregion
	}
}
