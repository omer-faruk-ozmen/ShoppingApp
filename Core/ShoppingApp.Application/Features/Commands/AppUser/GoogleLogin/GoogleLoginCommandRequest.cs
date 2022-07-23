using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ShoppingApp.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandRequest:IRequest<GoogleLoginCommandResponse>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string IdToken { get; set; }
        public string Provider { get; set; }
        public string PhotoUrl { get; set; }
    }
}




/*
email: "projecttesthesabi@gmail.com"
firstName: "Test"
id: "100478162814511352917"
idToken: "aswdf"
lastName: "HesabÄ±"
name: "Test HesabÄ±"
photoUrl: "https://lh3.googleusercontent.com/a/AItbvmmFD9PKCoILL5hg-NVPs5mK-LUWwQ7GweeTUQA=s96-c"
provider: "GOOGLE"
 */
