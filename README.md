# **Stock-app-api**
## endpoint
* ```/api/user/register```

  Purpose: Register user

  Method: ```Post```

  Request body:
  ```
  {
    "username": "Admin",
    "email": "Admin@example.com",
    "password": "Admin123@#",
    "passwordConfirmation": "Admin123@#"
    "role": "Admin"
  }
  ```
  Default role: "User"

  Response:
  ```
  {
    "userName": "User12",
    "isAdmin": true,
    "key": "your_token"
  }
  ```
* ```/api/user/login```

  Purpose: Login

  Method: ```Post```

  Request body:
  ```
  {
    "email": "User1@example.com",
    "password": "User1123@#"
  }
  ```
  Response:
  ```
  {
    "userName": "User1",
    "isAdmin": false,
    "key": "your_token"
  }
  ```
* ```/api/quote/ws?page=[value]?limit=[value]```

  Method: ```Get```

  *Clients can initiate a WebSocket connection to this api endpoint. Once connected, the server sends periodic updates on real-time stock quotes.*
* ```/api/watchlist/get?page=[value]?limit=[value]```

  Purpose: Get watch_list of current user

  Method: ```Get```
  
  Authorization Header:
  ```
  Authorization: Bearer your_access_token
  ```
  
  Response:
  ```
  [
    {
        "watchId": 4,
        "userId": 2037,
        "stockId": 88
    },
    {
        "watchId": 6,
        "userId": 2037,
        "stockId": 95
    },
    {
        "watchId": 5,
        "userId": 2037,
        "stockId": 99
    }
  ]
  ```
* ```/api/watchlist/add```

  Purpose: Add stock to current user's watch_list

  Method: ```Post```

   Authorization Header:
  ```
  Authorization: Bearer your_access_token
  ```

  Request body:
  ```
  {
    "stockId": 16
  }  
  ```
* ```/api/order/placeorder```

  Purpose: Place an order

  Method: ```Post```

   Authorization Header:
    ```
    Authorization: Bearer your_access_token
    ```

    Request body:
    ```
    {
      "StockId": 16,
      "OrderType": "Buy",
      "Direction": "Long",
      "Quantity": 50,
      "Price": 50,
      "Status": "Pending"
    }  
    ```
    *When adding an order, notifications and transactions are automatically added.*
  
* ```/api/order?page=[value]?limit=[value]```

  Purpose: Get orders of current user

  Method: ```Get```
  
  Authorization Header:
  ```
  Authorization: Bearer your_access_token
  ```
  
  Response:
  ```
  {
    "orders": [
        {
            "stockId": 2,
            "orderType": "Buy",
            "direction": "Long",
            "quantity": 10,
            "price": 100.5000,
            "status": "Pending",
            "orderDate": "2024-01-09T11:47:02.567"
        },
        {
            "stockId": 3,
            "orderType": "Sell",
            "direction": "Short",
            "quantity": 100,
            "price": 100.5000,
            "status": "Pending",
            "orderDate": "2024-01-09T12:34:34.91"
        },
        {
            "stockId": 16,
            "orderType": "Buy",
            "direction": "Long",
            "quantity": 50,
            "price": 50.0000,
            "status": "Pending",
            "orderDate": "2024-01-09T13:46:47.243"
        }
    ],
    "userId": 2037
  }
  ```
* ```/api/utils/transactions?page=[value]?limit=[value]```

  Purpose: Get transactions of current user

  Method: ```Get```
  
  Authorization Header:
  ```
  Authorization: Bearer your_access_token
  ```
  
  Response:
  ```
  {
    "transactions": [
        {
            "userId": 2037,
            "linkedAccountId": null,
            "transactionType": null,
            "amount": 1005.00,
            "transactionDate": "2024-01-09T04:47:04.55"
        },
        {
            "userId": 2037,
            "linkedAccountId": null,
            "transactionType": null,
            "amount": 10050.00,
            "transactionDate": "2024-01-09T05:34:36.403"
        },
        {
            "userId": 2037,
            "linkedAccountId": null,
            "transactionType": null,
            "amount": 2500.00,
            "transactionDate": "2024-01-09T06:46:48.457"
        }
    ],
    "userId": 2037
  }
  ```
* ```/api/utils/notifications?page=[value]?limit=[value]```

  Purpose: Get notifications of current user

  Method: ```Get```
  
  Authorization Header:
  ```
  Authorization: Bearer your_access_token
  ```
  
  Response:
  ```
  {
    "notifications": [
        {
            "userId": 2037,
            "notificationType": null,
            "content": "Your order has been Longed: 10 shares of PAST at 100.5000",
            "isRead": false
        },
        {
            "userId": 2037,
            "notificationType": null,
            "content": "Your order has been Shorted: 100 shares of POLIC at 100.5000",
            "isRead": false
        },
        {
            "userId": 2037,
            "notificationType": null,
            "content": "Your order has been Longed: 50 shares of FORWA at 50.0000",
            "isRead": false
        }
    ],
    "userId": 2037
  }
  ```
