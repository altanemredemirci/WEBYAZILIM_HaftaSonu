namespace _18_WebAPI.DTOs
{
    //ORTAK (Wrapper) DTO: Standart API Yanıt Yapısı

    /*
     * Başarılı Yanıt Örneği
    {
        "success":true,
        "message":"Ürün başarıyla eklendi",
        "data":{....}
    }

     * Başarısız Yanıt Örneği
    {
        "success":true,
        "message":"Ürün başarıyla eklendi",
        "data":null,
        "errors":["ID geçersiz"]
    }

     */
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }


        //Statik factory metodları: Kolay kullanım için

        public static ApiResponse<T> SuccessResponse(T data, string message = "İşlem başarılı")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, List<string>? errors=null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Errors = errors
            };
        }
    }

}
