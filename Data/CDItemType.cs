using System;

namespace Data
{
	/// <summary>Class representing a single Item Type.</summary>
	public class CDItemType
	{
		#region Member variables
		private int			m_iItemTypeID;
		private string	m_sItemTypeDesc;
		#endregion
		#region Properties
		public int ItemTypeID
		{
			get { return m_iItemTypeID; }
			set { m_iItemTypeID = value; }
		}
		public string ItemTypeDesc
		{
			get { return m_sItemTypeDesc; }
			set { m_sItemTypeDesc = value; }
		}
		#endregion
		#region Constructor/Destructor
		public CDItemType()
		{
		}
		#endregion
		#region Public methods
		#endregion
		#region Private methods
		#endregion
	}
}
