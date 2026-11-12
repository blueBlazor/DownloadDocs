namespace DownloadDocs.Helpers
{
    public enum ResponseCode
    {
        Ok = 200,
        Created = 201,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        UnprocessableContent = 422,
        InternalServerError = 500,
        ServiceUnavailable = 503
    }
    public sealed record Response<T>(bool isSuccess, T? value, string? message, int HttpCode)
    {
        public static Response<T> Success(T data, string? title, string? message, int HttpCode) => new(true, data, message, HttpCode);
        public static Response<T> Failure(string? title, string? message, int HttpCode) => new(false, default, message, HttpCode);

    }
    // ***API ERROR CODES***
    //Request succesvol verwerkt                200 OK
    //Resource succesvol aangemaakt             201 Created
    //Request bevat ongeldige input	            400	Bad Request
    //Authenticatie ontbreekt of is ongeldig    401	Unauthorized
    //Gebruiker heeft onvoldoende rechten	    403	Forbidden
    //Onverwachte fout tijdens verwerking	    500	Internal Server Error

    //***HandlerDispatch ERROR CODES***
    //Handler succesvol uitgevoerd	                  200  OK
    //Handler bestaat niet of is niet geregistreerd   500* Serverconfiguratieprobleem
    //Request - type komt niet overeen met handler	  500* Applicatiefout
    //Handler gooit onverwacht een exception	      500  Onverwachte serverfout

    //***Handler ERROR Codes***
    //Use-case succesvol uitgevoerd                   200 OK
    //Verplicht requestveld ontbreekt of is ongeldig  400 Bad Request
    //Speler bestaat niet	                          404 Not Found
    //Speler heeft geen DM-rechten                    403 Forbidden
    //Campagne bestaat niet                           404 Not Found
    //Sessie is al geopend                            409 Conflict
    //Businessregel verhindert de actie	              422 Unprocessable Content
    //Onverwachte exception                           500 Internal Server Error

    //***Repository laag ERROR CODES*** 
    // Record niet gevonden De gevraagde resource bestaat niet  404
    // Unieke constraint geschonden Resource bestaat al of veroorzaakt conflict	409
    // Database niet bereikbaar Tijdelijke infrastructuurstoring	503
    // Databasequery of opslag faalt onverwacht Interne serverfout	500
    // Ongeldige query door programmeerfout    Interne serverfout  500
}
