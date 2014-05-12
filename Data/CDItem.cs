using System;

namespace Data
{
	/// <summary>Class representing a single KnowledgeBase item</summary>
	public class CDItem
	{
		#region Member Variables
		private int		m_iItemID,
									m_iItemTypeID;
		private string m_sItemDesc,
									m_sItemInfo;  
		DateTime			m_dtDateCreated;
		CDItemType		m_oItemType;
		CDSystem			m_oSystem;
		#endregion
		#region Properties
		#endregion
		#region Constructor/Destructor
		public CDItem()
		{
			m_dtDateCreated = DateTime.Now;
		}
		public CDItem(string pItemDesc, string pItemInfo)
		{
			m_sItemDesc			= pItemDesc;
			m_sItemInfo			= pItemInfo;
			m_dtDateCreated = DateTime.Now;
		}
		#endregion
		#region Public methods
		#endregion
		#region Private methods
		#endregion
	}
}
