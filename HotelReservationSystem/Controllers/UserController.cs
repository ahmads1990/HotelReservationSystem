using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.CQRS.Users.Commands;
using FOOD_APP_JSB_2.CQRS.Users.Queries;
using FOOD_APP_JSB_2.Data.Enums;
using FOOD_APP_JSB_2.Filters;
using FOOD_APP_JSB_2.Helpers;
using FOOD_APP_JSB_2.ViewModels.Responses;
using FOOD_APP_JSB_2.ViewModels.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using OtpNet;


namespace FOOD_APP_JSB_2.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    IMediator _mediator;
    private readonly TokenHelper _tokenHelper;

    public UserController(IMediator mediator, TokenHelper tokenHelper)
    {
        _mediator = mediator;
        _tokenHelper = tokenHelper;
    }

    [HttpPost]
    [Authorize]
    [TypeFilter(typeof(CustomRequestCultureProvider), Arguments = new object[] { Feature.Register })]
    public async Task<bool> Register(UserViewModel viewModel)
    {
        var user = viewModel.Map<RegisterUserCommand>();
        var isAdded = await _mediator.Send(user);
        return isAdded;
    }
    
    [HttpGet]
    [Authorize]
    [TypeFilter(typeof(CustomizeAuthorizeAttribute), Arguments =new object[] {Feature.GetByID})]
    public async Task<UserViewModel> GetByID(int id)
    {
        var istructor = await _mediator.Send(new GetUserByIDQuery(id));

        return istructor;
    }

    [HttpPost]
    public async Task<ResponseViewModel<UserLoginResult>> Login(LoginViewModel viewModel)
    {
        var user = viewModel.Map<UserLogInQuery>();
        var userData = await _mediator.Send(user);
        UserLoginResult result = new UserLoginResult { Token = null, TwofactorAuthEnabled = userData.Item2 };
        if (userData.Item1 != 0 && !userData.Item2)
        {
            var token = _tokenHelper.GenerateToken(userData.Item1);
            result.Token = token;
            return new SuccessResponseViewModel<UserLoginResult>(result);
        }
        if (userData.Item1 != 0 && userData.Item2)
        {
            return new SuccessResponseViewModel<UserLoginResult>(result);
        }
        return new FaluireResponseViewModel<UserLoginResult>(ErrorCode.UserNotFound, ErrorCode.UserNotFound.ToString());
    }

    [HttpGet]
    public string GetLink()
    {
        var secretKey = KeyGeneration.GenerateRandomKey(20);
        var base32Key = Base32Encoding.ToString(secretKey);

        var appName = "UpSkilling-FoodApp-JSB2";
        var userName = "Adel";

        string otpUrl = $"otpauth://totp/{appName}:{userName}?secret={base32Key}&issuer={appName}";

        return otpUrl;
    }

    [HttpPost]
    public bool VerifyOTP(string tempToken, string otp)
    {
        var secretKey = "5WM6M5A3NZ65RTKQEPKWUIGEO6DCUSD2"; // get the secret key for the specific user
        var key = Base32Encoding.ToBytes(secretKey);
        var totp = new Totp(key);

        var isValid = totp.VerifyTotp(otp, out long timeStepMatched);

        if (isValid)
        {
            //return TokenHelper.GenerateToken(10, "Ali", Role.Instructor);
        }

        return isValid;
    }
}