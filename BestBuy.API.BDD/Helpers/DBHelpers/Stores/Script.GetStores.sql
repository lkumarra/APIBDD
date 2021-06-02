SELECT 
[stores].[id],  
[stores].[name],  
[stores].[type],  
[stores].[address],  
[stores].[address2],  
[stores].[city],  
[stores].[state],  
[stores].[zip],  
[stores].[lat],  
[stores].[lng],  
[stores].[id], 
[stores].[hours],  
CAST([stores].[createdAt] as varchar) as createdAt, 
CAST([stores].[updatedAt] as varchar) as updatedAt
from [stores] ORDER By 
[stores].[id] ASC LIMIT 10