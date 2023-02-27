# On Call Developer API

We have a bunch of services that have a `/status` resource and they've taken to putting the contact information for the help desk in this response.
Keeping those things synced up is a pain.

We want a new service that is responsible for keeping track of the current on call developer.

This service will expose and HTTP interface that allows *other* services to request information on which developer should be contacted in emergencies, etc.

## What we do now

During *business hours* we refer people to the primary support person, Bob Smith.
After business hours, we refer people to our out-sourced support number.

## Requirements

### On Call Developer
We want to be able to rotate through a list of developers one week at a time. Bob is training another developer for the role, and she should be ready "soon".

We'd like to be able to alter the schedule if needed (if Bob or his partner switch shifts, are OOO, or we add other support people).

### What are the "Business Hours"?

We have a calendar we are formulating, including days like federal holidays, etc. where we are closed.
Right now, just Monday-Friday, 9:00 AM - 5:00 PM


### Design The API

#### Resources
- "An important thingy we want to provide access to"
- Methods: GET, POST, PUT, DELETE
- URI:
    `https://api.hypertheory.com/support/oncalldeveloper"
    - Scheme: http | https
    - Authority: "api.hypertheory.com" - "Server"
    - Path (path to the resource): /support/oncalldeveloper
- Constraints of HTTP
    - Client/Server - the server is *passive* - it waits for a request, and makes a response.
- http://localhost/oncalldeveloper


#### Representations

Are the "data" that goes to the API or FROM the API.

GET /oncalldeveloper

200 Ok

```json
{
    "contact": {
        "firstName": "Bob",
        "lastName": "Smith",
        "email": "bob@aol.com",
        "phoneNumber": "ext123"
    }
}

```