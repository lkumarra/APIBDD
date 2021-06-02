SELECT 
services.id, 
services.name, 
CAST(services.createdAt as varchar) as createdAt, 
CAST(services.updatedAt as varchar) as updatedAt, 
CAST(storeservices.createdAt as varchar) as stscreatedAt, 
CAST(storeservices.updatedAt as varchar) as stsupdatedAt, 
storeservices.storeId, storeservices.serviceId 
from services INNER JOIN storeservices 
On storeservices.serviceId == services.id 
WHERE storeservices.storeId= @storeid ORDER BY services.id ASC