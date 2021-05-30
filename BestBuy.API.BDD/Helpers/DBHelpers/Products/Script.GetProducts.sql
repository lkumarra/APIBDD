﻿Select DISTINCT products.id, products.name, products.type, products.price, products.upc,products.shipping,products.description,products.description,products.model,products.url, products.image, Cast(products.createdAt as VARCHAR) as createdAt, Cast(products.updatedAt as VARCHAR) as updatedAt from ((products INNER JOIN productcategory on products.id = productcategory.productId)INNER JOIN categories on productcategory.categoryId = categories.id) ORDER BY products.id ASC LIMIT 10