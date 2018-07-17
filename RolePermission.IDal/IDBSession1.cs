
namespace RolePermission.IDAL
{
	public partial interface IDBSession
    {
		ISMFIELDRepository ISMFIELDRepository{get;}
		ISMFUNCTBRepository ISMFUNCTBRepository{get;}
		ISMLOGRepository ISMLOGRepository{get;}
		ISMMENUROLEFUNCTBRepository ISMMENUROLEFUNCTBRepository{get;}
		ISMMENUTBRepository ISMMENUTBRepository{get;}
		ISMROLETBRepository ISMROLETBRepository{get;}
		ISMUSERTBRepository ISMUSERTBRepository{get;}
    }
}