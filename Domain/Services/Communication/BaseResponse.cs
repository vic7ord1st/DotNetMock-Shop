namespace mockshop.API.Domain.Services.Communication {
    public abstract class BaseResponse {
        public bool _success {get; set;}
        public string _message {get; set;}

        public BaseResponse (bool success, string message){
            _success = success;
            _message = message;
        }
    }
}