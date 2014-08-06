AnemicStuff (IDEAS)
===========

The idea here is to move towards a crud paradigm, while still supporting our old code


##More Anemic
Going crud style

###Save / POST / PUT / PATCH
     /entities/{entityTypeName}/{id}
Payload = json of attributes & values

###Load / Get
####by id
     /entities/{entityTypeName}/{id}
####query (using odata)
    /entities/{entityTypeName}?$filter=Name eq bacon

####Delete
    /entities/{entityTypeName}/{id}
    
    

##Less Anemic

Not everything has to be so anemic.  There is also:

###Commands / Put
Commands are useful when CRUD is not expressive enough.  For example, establishing a releationship between 2 companies.

     /commands/{commandTypeName}/{correlationId}
Payload = json body of command

###Queries / Get (params + Odata)
Queries are useful where there is some structured data to return, perhaps some inner joins or things that we'll leave up to the server.

     /queries/{queryName}?param1=a&param2=b?$filter=Name eq bacon


##Notes

We should rewrite functional documentaton around commands, queries, and entities.  There are some good open source docs specs nowadays that could save us time.

We would then leave the existing api as-is, which would eventually be retired.

As an aside, it appears that the actor paradigm will be short lived, as either a command would be persisted, or an entity would be PATCHED / POSTED / PUTTED without a specific requestmodel being needed.  Instead, we would use a JObject and parse out the json bits at runtime.
