using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class Merchant
    {
        private readonly IClient _webClient;

        /// <inheritdoc />
        public Merchant()
        {
            _webClient = new Client("", "");
        }

        /// <inheritdoc />
        public Merchant(IClient webClient)
        {
            _webClient = webClient;
        }

        /**
         * Add a merchant
         *
         * Create a new submerchant.
         * The format of the option array is as follows
         * array(
         *      // Required
         *      'companyName' => 'The Name',
         *      'cocNumber' => '123456789',
         *      'street' => 'Street',
         *      'houseNumber' => '123',
         *      'postalCode' => '1234 AA',
         *      'city' => 'City',
         *      'accounts' => array(
         *          // Minimum of 1 account, you can add more, one account must be primary, the other accounts cannot be primary
         *          array(
         *              'primary' => true, // One account must be primary
         *              'email' => 'email@test.nl',
         *              'firstname' => 'First',
         *              'lastname' => 'Last',
         *              'gender' => 'male', // 'male' or 'female'
         *              'authorisedToSign' => 2, //0 not authorised, 1 authorised independently, 2  shared authorized to sign
         *              'ubo' => true, // Ultimate beneficial owner (25% of more shares)
         *          ),
         *          array(
         *              'primary' => false,
         *              'email' => 'email2@test.nl',
         *              'firstname' => 'Mede',
         *              'lastname' => 'Eigenaar',
         *              'gender' => 'female', // 'male' or 'female'
         *              'authorisedToSign' => 2, //0 not authorised, 1 authorised independently, 2  shared authorized to sign
         *              'ubo' => true, // Ultimate beneficial owner (25% of more shares)
         *          )
         *       ),
         *      // Optional
         *      Do you want to send a registration email to the accounts.
         *      The options are:
         *      0 - No email is sent
         *      1 - The default registration email is sent
         *      2 - The shortened alliance registration email is sent
         *      'sendEmail' => 1, // see above
         *      'countryCode' => 'NL',
         *      'bankAccountOwner' => 'Firstname Lastname',
         *      'bankAccountNumber' => 'NL91ABNA0417164300',
         *      'bankAccountBIC' => 'ABNANL2A',
         *      'vatNumber' => 'NL123412413',
         *      'packageName' => 'Alliance', // Alliance or AlliancePlus
         *
         *      Set to true if you want to be able to add a debit invoice to the account of this merchant.
         *      Your invoice will be subtracted from the merchants account.
         *      You will need to ask the merchant for permission before you can set this value to true
         *      'settleBalance' => false, // see above
         *      'payoutInterval' => 'week' //day, week or month
         *  )
         *
         * @param array  options see Description
         * @return Result\Merchant\Add
         * @throws Error
         * @throws Required
         */

        public API.Merchant.Add.Response Create(API.Merchant.Add.Request request)
        {
            // api = new Api\AddMerchant();

            //    if (!String.IsNullOrEmpty( options['accounts']))
            //    {
            //        self::_addAccounts( options['accounts'],  api);
            //    }
            // merchant = self::_getMerchant( options);
            // api->setMerchant( merchant);

            // bankAccount = self::_getBankAccount( options);
            //    if (!empty( bankAccount))
            //    {
            //     api->setBankAccount( bankAccount);
            //    }

            // settings = self::_getSettings( options);
            //    if (!empty( settings))
            //    {
            //     api->setSettings( settings);
            //    }

            // result =  api->doRequest();
            
            var response = _webClient.PerformRequest(request);
            return API.Merchant.Add.Response.FromRawResponse(response);
        }

        /**
         * Add the accounts to the addMerchant API
         *
         * @param array  accounts
         * @param Api\AddMerchant  api
         * @throws Error
         * @throws Required
         */
        private object _addAccounts(ICollection<object> accounts, object /*Models.Merchant.Create  */ api)
        {
            if ( accounts.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(accounts));
            }

            foreach (var account in accounts) {
             //   if (!!String.IsNullOrEmpty( account['email']))
             //   {
             //       throw new Required('account - email');
             //   }
             //   if (!!String.IsNullOrEmpty( account['firstname']))
             //   {
             //       throw new Required('account - firstname');
             //   }
             //   if (!!String.IsNullOrEmpty( account['lastname']))
             //   {
             //       throw new Required('account - lastname');
             //   }
             //   if (!!String.IsNullOrEmpty( account['gender']))
             //   {
             //       throw new Required('account - gender');
             //   }

             //   if (!!String.IsNullOrEmpty( account['authorizedToSign']))
             //   {
             //       if (!String.IsNullOrEmpty( account['authorisedToSign']))
             //       {
             //        account['authorizedToSign'] =  account['authorisedToSign'];
             //       }
             //       else
             //       {
             //           throw new Required('account - authorizedToSign');
             //       }
             //   }

             //   if (!!String.IsNullOrEmpty( account['authorizedToSign']))
             //   {
             //       if (!!String.IsNullOrEmpty( account['authorisedToSign']))
             //       {
             //           throw new Required('account - authorizedToSign');
             //       }
             //    account['authorizedToSign'] =  account['authorisedToSign'];
             //   }

             //   if (!!String.IsNullOrEmpty( account['ubo']))
             //   {
             //       throw new Required('account - ubo');
             //   }
             //   if (!!String.IsNullOrEmpty( account['uboPercentage']))
             //   {
             //       if (is_numeric( account['ubo']) &&  account['ubo'] > 0 &&  account['ubo'] <= 100) {
             //        account['uboPercentage'] =  account['ubo'];
             //        account['ubo'] = true;
             //       }
             //   }
             //account['ubo'] = (integer) account['ubo'];

             //   if (!String.IsNullOrEmpty( account['hasAccess']))
             //   {
             //    account['hasAccess'] = (integer)  account['hasAccess'];
             //   }
             //   if (!String.IsNullOrEmpty( account['useCompanyAuth']))
             //   {
             //    account['useCompanyAuth'] = (integer)  account['useCompanyAuth'];
             //   }

             //api->addAccount( account);

            }

            return new object();
        }

        /**
         * @param array  options
         */
        private object _getMerchant( /*options*/)
        {
            var merchant = new Array[0];

         //   if (!!String.IsNullOrEmpty( options['companyName']))
         //   {
         //       throw new Required('companyName');
         //   }
         //merchant['name'] =  options['companyName'];

         //   if (!!String.IsNullOrEmpty( options['cocNumber']))
         //   {
         //       throw new Required('cocNumber');
         //   }
         //merchant['coc'] =  options['cocNumber'];

         //   if (!!String.IsNullOrEmpty( options['street']))
         //   {
         //       throw new Required('street');
         //   }
         //merchant['street'] =  options['street'];

         //   if (!!String.IsNullOrEmpty( options['houseNumber']))
         //   {
         //       throw new Required('houseNumber');
         //   }
         //merchant['houseNumber'] =  options['houseNumber'];

         //   if (!!String.IsNullOrEmpty( options['postalCode']))
         //   {
         //       throw new Required('postalCode');
         //   }
         //merchant['postalCode'] =  options['postalCode'];

         //   if (!!String.IsNullOrEmpty( options['city']))
         //   {
         //       throw new Required('city');
         //   }
         //merchant['city'] =  options['city'];

         //   if (!!String.IsNullOrEmpty( options['countryCode']))
         //   {
         //       throw new Required('countryCode');
         //   }
         //merchant['countryCode'] =  options['countryCode'];

         //   /**
         //    * Optional
         //    */
         //   if (!String.IsNullOrEmpty( options['vatNumber']))
         //   {
         //    merchant['vat'] =  options['vatNumber'];
         //   }
         //   if (!String.IsNullOrEmpty( options['houseNumberAddition']))
         //   {
         //    merchant['houseNumberAddition'] =  options['houseNumberAddition'];
         //   }
            return  merchant;
        }

        private object _getBankAccount( /*options*/)
        {
         var bankAccount = new Array[0];
            //if (!String.IsNullOrEmpty( options['bankAccountOwner']))
            //{
            // bankAccount['bankAccountOwner'] =  options['bankAccountOwner'];
            //}
            //if (!String.IsNullOrEmpty( options['bankAccountNumber']))
            //{
            // bankAccount['bankAccountNumber'] =  options['bankAccountNumber'];
            //}
            //if (!String.IsNullOrEmpty( options['bankAccountBIC']))
            //{
            // bankAccount['bankAccountBIC'] =  options['bankAccountBIC'];
            //}
            return  bankAccount;
        }

        private object _getSettings( /*options*/)
        {
         var settings = new Array[0];

            //if (!String.IsNullOrEmpty( options['packageName']))
            //{
            // settings['packageName'] =  options['packageName'];
            //}
            //if (!String.IsNullOrEmpty( options['packageName']))
            //{
            // settings['packageName'] =  options['packageName'];
            //}

            //if (!String.IsNullOrEmpty( options['sendEmail']))
            //{
            // settings['sendEmail'] =  options['sendEmail'];
            //}
            //if (!String.IsNullOrEmpty( options['settleBalance']))
            //{
            // settings['settleBalance'] = (integer) options['settleBalance'];
            //}
            //if (!String.IsNullOrEmpty( options['referralProfileId']))
            //{
            // settings['referralProfileId'] =  options['referralProfileId'];
            //}
            //if (!String.IsNullOrEmpty( options['clearingInterval']))
            //{
            // settings['clearingInterval'] =  options['clearingInterval'];
            //}
            return  settings;
        }

        /**
         * @param  options
         * @return Result\Merchant\Get
         */
        public object get( /*options*/)
        {
         //api = new Api\GetMerchant();
         //   if (!String.IsNullOrEmpty( options['merchantId']))
         //   {
         //    api->setMerchantId( options['merchantId']);
         //   }

         //result =  api->doRequest();

            return new object(); // Result\Merchant\Get( result);
        }

        public object getList( /*options = array()*/)
        {
         //api = new Api\GetMerchants();

         //   if (!String.IsNullOrEmpty( options['state']))
         //   {
         //    api->setState( options['state']);
         //   }

         //result =  api->doRequest();

            return new object(); // Result\Merchant\GetList( result);
        }

        /**
         * @param  options
         */
        public object addBankAccount(/*options = array()*/)
        {
        // api = new Api\AddBankAccount();

        //    if (!String.IsNullOrEmpty( options['merchantId']))
        //    {
        //     api->setMerchantId( options['merchantId']);
        //    }
        //    if (!String.IsNullOrEmpty( options['returnUrl']))
        //    {
        //     api->setReturnUrl( options['returnUrl']);
        //    }
        //    if (!String.IsNullOrEmpty( options['bankId']))
        //    {
        //     api->setBankId( options['bankId']);
        //    }

        // result =  api->doRequest();

        //    return  result['issuerUrl'];
            return new object();
        }
}
}