SELECT
"Id",
"ReservePrice",
"Seller",
"Winner",
"SoldAmount",
"CurrentHighBid",
"CreatedAt",
"UpdatedAt",
"AuctionEnd",
"Status"
FROM "Auctions";

SELECT
"SequenceNumber",
"EnqueueTime",
"SentTime",
"Headers",
"Properties",
"InboxMessageId",
"InboxConsumerId",
"OutboxId",
"MessageId",
"ContentType",
"MessageType",
"Body",
"ConversationId",
"CorrelationId",
"InitiatorId",
"RequestId",
"SourceAddress",
"DestinationAddress",
"ResponseAddress",
"FaultAddress",
"ExpirationTime"
FROM "OutboxMessage";

SELECT "Id", "Make", "Model", "Year", "Color", "Mileage"
FROM "Items";

SELECT
"Id",
"UserName",
"NormalizedUserName",
"Email",
"NormalizedEmail",
"EmailConfirmed",
"PasswordHash",
"SecurityStamp",
"ConcurrencyStamp",
"PhoneNumber",
"PhoneNumberConfirmed",
"TwoFactorEnabled",
"LockoutEnd",
"LockoutEnabled",
"AccessFailedCount"
FROM "AspNetUsers";
