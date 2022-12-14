CREATE OR REPLACE PROCEDURE create_user(
	inout userid uuid, 
	inout firstName text, 
	inout lastName text,
	inout BVN text,
	inout PIN text,
	inout Email text,
	inout createdAt timestamptz,
	inout updatedAt timestamptz)
LANGUAGE SQL
BEGIN ATOMIC
	
	INSERT INTO "User"("UserId", "FirstName", "LastName", "BVN", "Pin", "Email", "createdAt", "updatedAt") 
	VALUES (userid, firstName, lastName, BVN, PIN, Email, createdAt, updatedAt);
	
	INSERT INTO "Account"("BVN", "AccountId","AccountNumber","createdAt","updatedAt","AccountBalance") 
	VALUES(BVN, gen_random_uuid(),  account_numberfn(), createdAt, updatedAt , 0);
	
	Update "User" Set "AccountId" = (Select "AccountId" from "Account" where BVN = BVN ) where "UserId" = userid;
	
	SELECT UserId, BVN, FirstName, LastName, PIN, Email, createdAt, updatedAt from "User" where "UserId" = userid;
	
	
END;