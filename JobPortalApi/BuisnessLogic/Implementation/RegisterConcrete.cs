using JobPortalApi.BuisnessLogic.Interfaces;
using JobPortalApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using JobPortalApi.ViewModel;
using JobPortalApi.Models;
using JobPortalApi.Common;


namespace JobPortalApi.BuisnessLogic.Implementation
{
    public class RegisterConcrete : IRegister
    {

        private UnitOfWork unitOfWork = new UnitOfWork();
        private IEnumerable<State> stateList = new List<State>();
        public string InsertReg(Register reg)
        {
            try
            {
                Tbl_Registration objReg = new Tbl_Registration();

                if (reg != null)
                {
                    objReg.RegistrationId = Guid.NewGuid();

                    objReg.Reg_Type = reg.RegType;
                    objReg.FirstName = reg.FirstName;
                    objReg.LastName = reg.LastName;
                    objReg.Image = reg.Image;
                    objReg.EmailId = reg.EmailId;
                    objReg.PhoneNumber = reg.PersonalNumber;
                    objReg.UserName = reg.UserName;
                    objReg.CountryId = reg.CountryId;
                    objReg.StateId = reg.StateId;
                    objReg.CityId = reg.CityId;
                    objReg.Password = reg.Password;
                    objReg.Gender = reg.Gender;
                    objReg.PinCode = reg.PinCode;
                    objReg.DateOfBirth = reg.DataOfBirth;
                    objReg.CreatedDate = System.DateTime.Now;
                    objReg.Address = reg.Address;
                    objReg.ActivationCode = Guid.NewGuid();
                    objReg.EmailVerified = false;
                }

                unitOfWork.RegisterRepository.Insert(objReg);

                int i = unitOfWork.Save();

                if (i > 0)
                {

                    SendVerificationLinkEmail(reg.EmailId, objReg.ActivationCode.ToString(), reg.Url);
                    return Constant.EmailMessage.ToString();
                }
                else
                {
                    return Constant.InsertFaild.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SendVerificationLinkEmail(string emailId, string activationcode, string url)
        {
            var varifyUrl = url + activationcode;
            var fromMail = new MailAddress("mithileshdotnet@gmail.com", "welcome applicant");
            var toMail = new MailAddress(emailId);
            var frontEmailPassowrd = "ckdouajlkckgrhgo";
            string subject = "Your account is successfull created";
            string body = "<br/><br/>We are excited to tell you that your account is" +
        " successfully created. Please click on the below link to verify your account" +
        " <br/><br/><a href='" + varifyUrl + "'>" + varifyUrl + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, frontEmailPassowrd)

            };
            using (var message = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);

        }

        public bool CheckExistUser(string UserName)
        {
            var value = unitOfWork.RegisterRepository.Get().Where(a => a.UserName == UserName).Any();
            return value;

        }
    }
}



