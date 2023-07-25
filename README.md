# Suss Backend Challenge

# API Definitions


## Create Campaign

#### Create Campaign Request

```js
POST /api/campaigns
```

```json
{
  "name": "Ads Campaign",
  "startDate": "07/22/2023",
  "endDate": "08/22/2023",
  "serviceId": 1
}
```

### Create Campaign Response

```js
201 Created
```

```yml
Location: {{host}}/campaigns/{{id}}
```

```json
{
  "id": 1,
  "name": "Ads Campaign",
  "startDate": "07/22/2023",
  "endDate": "08/22/2023",
  "serviceId": 1
}
```

## Get Campaign

### Get All Campaigns Request

```js
GET /campaigns
```

### Get All Campaigns Response

```js
200 Ok
```

```json
[
  {
    "id": 1,
    "name": "Ads Campaign",
    "startDate": "07/22/2023",
    "endDate": "08/22/2023",
    "serviceId": 1
  },
  {
      "id": 1,
      "name": "Sms Campaign",
      "startDate": "07/22/2023",
      "endDate": "08/22/2023",
       "serviceId": 2
    },
]
```
### Get Campaign Request

```js
GET /campaigns/{{id}}
```

### Get Campaign Response

```js
200 Ok
```

```json
{
  "id": 1,
  "name": "Ads Campaign",
  "startDate": "07/22/2023",
  "endDate": "08/22/2023",
  "serviceId": 1
}
```

## Update Campaign

### Update Campaign Request

```js
PUT /campaigns/{{id}}
```

```json
{
  "id": 1,
  "name": "Ads Campaign",
  "startDate": "07/22/2023",
  "endDate": "08/22/2023",
  "serviceId": 1
}
```

### Update Campaign Response

```js
204 No Content
```

```yml
Location: {{host}}/campaigns/{{id}}
```

## Delete Campaign

### Delete Campaign Request

```js
DELETE /campaigns/{{id}}
```

### Delete Campaign Response

```js
204 No Content
```
