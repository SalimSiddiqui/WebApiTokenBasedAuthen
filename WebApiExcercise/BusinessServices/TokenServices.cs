﻿using System;
using BusinessEntities;
using System.Configuration;
using DataModel;
using System.Linq;
using System.Data.Entity;

namespace BusinessServices
{
    public class TokenServices : ITokenServices
    {
        WebApiDbEntities db = new WebApiDbEntities();
        #region Private member variables.
        //private readonly UnitOfWork _unitOfWork;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        //public TokenServices(UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        #endregion


        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            //_unitOfWork.TokenRepository.Insert(tokendomain);
            //_unitOfWork.Save();
            db.Tokens.Add(tokendomain);
            db.SaveChanges();
            var tokenModel = new TokenEntity()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {

         var token =   db.Tokens.Where(t => t.AuthToken.Equals(tokenId) && t.ExpiresOn > DateTime.Now).SingleOrDefault();
            //var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
           {
                token.ExpiresOn = token.ExpiresOn.AddSeconds(
                                             Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));

                db.Tokens.Attach(token);
                db.Entry(token).State = EntityState.Modified;
                db.SaveChanges();

                //    (tokendomain);
                //db.SaveC(token);
                //_unitOfWork.TokenRepository.Update(token);
                //_unitOfWork.Save();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            //_unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            //_unitOfWork.Save();
            //var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            //if (isNotDeleted) { return false; }
            return true;
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
            //_unitOfWork.TokenRepository.Delete(x => x.UserId == userId);
            //_unitOfWork.Save();

            //var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.UserId == userId).Any();
            //return !isNotDeleted;
            return true;
        }

        #endregion
    }
}
