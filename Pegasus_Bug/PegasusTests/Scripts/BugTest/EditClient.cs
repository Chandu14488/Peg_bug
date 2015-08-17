using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditClient : DriverTestCase
    {
        [TestMethod]
        public void editClient()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Variables 
            String pnumber = "989898" + RandomNumber(1111,9999);
            String gmail = "tester" + RandomNumber(99, 999) + "@gmail.com";
            String ymail = "testing" + RandomNumber(99, 999) + "@yopmail.com";
            String cname = "tttssss" + RandomNumber(1, 999);

            var name = "DBAName" + GetRandomNumber();


            //Initializing the objects  
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var customerRelationshipHelper = new CustomerRelationshipHelper(GetWebDriver());
            var updateRateFees = new UpdateRateFeesHelper(GetWebDriver());
            var terminalsAndEquipment = new TerminalsAndEquipmentHelper(GetWebDriver());
            var ownersHelper = new OwnersHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
            clientHelper.ClickElement("ClickOnClientTab");

            //Verify user redirect at Client screen
            clientHelper.VerifyText("AddClients/Header", "Clients");


            //Click on Create client link
            clientHelper.ClickElement("AddClients/Create");


            //  clientHelper.VerifyPageText("tetrytrytryutryurtst");

            // Enter Company DBA Name
            clientHelper.TypeText("AddClients/CompanyDBAName", name);

            //Click on Save BUtton
            clientHelper.ClickElement("AddClients/ClickOnSaveBtn");
            clientHelper.WaitForWorkAround(8000);

            //Click on Clients in Topmenu
            clientHelper.ClickElement("ClickOnClientTab");

            //Search Client
            clientHelper.TypeText("SearchAddClient",name);
            clientHelper.WaitForWorkAround(10000);

            //Click on Edit
            clientHelper.ClickElement("EditClient");


            // Enter Enter Company Legal Name
            clientHelper.TypeText("AddClients/CompanyLegalName", "New Company");

            // Enter Enter Company Perisident
            clientHelper.TypeText("AddClients/CompanyPresident", "Tester");

            // Enter Company CFO
            clientHelper.TypeText("AddClients/CompanyCFO", "TEST CFO");

            // SELECT Ownership Type
            clientHelper.Select("AddClients/OwnershipType", "Sole Proprietor");

            // SELECT Tax Classification 
            clientHelper.Select("AddClients/TaxClassification", "Disregarded Entity");

            // Enter SSN Federal TaxID
            clientHelper.TypeText("AddClients/SSNFederalTaxID", "abc1234");

            //Select Exempt payee
            clientHelper.Select("ExemptPayee", "Y");

            //State Incorporate
            clientHelper.Select("StateIncorporateEdit", "AL");


            //select Corporation Type
            clientHelper.Select("CorporateEdit", "C");

            //select TimeZone
            clientHelper.Select("EditTimEZone", "2");


            //################################## DESCRIPTION    #######################################

            // Click on Expand button
            clientHelper.ClickElement("clickOnExpandBtn");

            //Enter Description
            //  clientHelper.TypeText("CompnyDetailEnterDescription", "");        


            //################################## MORE COMPANY DETAIL    #######################################

            //Click on Company Detail Expand btn
            clientHelper.ClickElement("MoreCmpyDetlExpandBtn");

            //Click on CompanyDetailMultipleLocationYes
            //       clientHelper.ClickElement("AddClients/CompanyDetailMultipleLocationYes");

            //Enter Total Of Location
            //       clientHelper.TypeText("AddClients/TotalOfLocation", "1");

            //SELECT Delivery Option Mail
            clientHelper.Select("AddClients/DeliveryOptionMail", "Corporate");

            // select Delivery Statement
//            clientHelper.Select("AddClients/DeliveryStatement", "Outlet");

            // select Delivery Statement
            clientHelper.Select("AddClients/DeliverBy", "0");

            // Click on Business Environmemnt storefront check box
            clientHelper.ClickElement("AddClients/BusinessEnvironmemntstorefront");

            // Click on Business Enrnmnt Tradeshow
            clientHelper.ClickElement("AddClients/BusinessEnrnmntTradeshow");

            // Click on Advertising Method Catalogue
            clientHelper.ClickElement("AddClients/AdvertisingMethodCatalogue");


            // Click on Advertising Method Internet Email
            clientHelper.ClickElement("AddClients/AdvertisingMethodInternetEmail");


            // Click on OwnerShip Legal Entity
            clientHelper.ClickElement("AddClients/OwnerShipLegalEntity");

            // Click on Corporate Headquater
            clientHelper.ClickElement("AddClients/CorporateHeadquater");


            //################################ SITE SURVEY     ################################################


            // Click on Site Survey Expand btn
            clientHelper.ClickElement("SiteSurvey");


            // Select Merchant Location
            clientHelper.Select("AddClients/MerchantLocation", "Shopping Center");

            // Select SquareFootage
            clientHelper.Select("AddClients/SquareFootage", "0-200");

            // select AreaZoned
            clientHelper.Select("AddClients/AreaZoned", "Industrial");

            // Click on Window checkbox
            clientHelper.ClickElement("AddClients/Window");


            // Click on Merchant Location
            clientHelper.Select("AddClients/MerchantOccupies", "Other");

            //Select Number Of floor
            clientHelper.Select("AddClients/NoOfFloor", "2-4");

            //Select Remaining Floor Occuoied
            clientHelper.Select("AddClients/RemainingFloorOccuoied", "Commercial");

            //Select Does amount Merchant Salves
            clientHelper.Select("AddClients/DoesamountMerchantSalves", "Y");


            //Select Merchant Own Leages 
            clientHelper.Select("AddClients/MerchantOwnLeages", "Owns");


            //Select IfApplicableleaser
            clientHelper.TypeText("AddClients/IfApplicableleaser", "test");

            //Other comment
            clientHelper.TypeText("AddClients/OtherComment", "test comment");


            //Enter Number Of Employees
            clientHelper.TypeText("AddClients/NumberOfEmployees", "4");


            //Enter Number of Registers
            clientHelper.TypeText("AddClients/NumberofRegisters", "12");

            //Click on GoodsSErvivesCharged
            clientHelper.ClickElement("AddClients/GoodsSErvivesCharged");

            //Select Does Business Appear Representive 
            clientHelper.Select("AddClients/DoesBusinessAppearRepresentive", "Y");


//####################    ADDRESSESS

            //Click on Addresses Contact tab
            clientHelper.ClickElement("ClickOnAddressesContactstab");


            // ####################### ADDRESSES  LOCATION ADDRESS   ############################


            // Enter Address Line 1
            clientHelper.TypeText("AddClients/AddressLine1", "Sector 64");

            // Enter Address Line 2
            clientHelper.TypeText("AddClients/AddressLine2", "B-69");


            // Enter Country Name
            clientHelper.TypeText("AddClients/Country", "India");

            // Enter City
            clientHelper.TypeText("AddClients/City", "NOIDA");

            // Select Country dropdown
            clientHelper.Select("AddClients/Countrydd", "United States");
            clientHelper.WaitForWorkAround(4000);

            // Select State Name
            clientHelper.Select("AddClients/State", "CT");

            // Enter Zip Code
            //    clientHelper.TypeText("AddClients/ZipCode", "201005");


            // Click On Checkbox Do Not Solicit
            clientHelper.ClickElement("AddClients/DoNotSolicit");


            // Click on Add Remark 1
            clientHelper.ClickElement("AddClients/AddRemark1");

            // Enter Add Remark Description
            clientHelper.TypeText("AddClients/AddRemarkDescription", "This Is Testing Remark");

            // Click on Close Remark 1
            clientHelper.ClickElement("AddClients/CloseRemark1");


            // Enter Address Line 1 Mailing address
            clientHelper.TypeText("AddClients/AddressLine1Mailinadd", "F/C 89");

            // Enter Address Line 2 Mail Address
            clientHelper.TypeText("AddClients/AddressLine2MailAdd", "ABC");

            // Enter Country Mailing Address 
            clientHelper.TypeText("AddClients/CountryMailingAdd", "United States");


            // Enter City Mailing Address
            clientHelper.TypeText("AddClients/CityMailingAdd", "Test City");

            // Click Do Not Solicit Mailing Address
            clientHelper.ClickElement("AddClients/DoNotSolicitMailingAdd");


            // click Current ChkBox Mailing Address
            clientHelper.ClickElement("AddClients/CurrentChkBoxMailingAddress");

            // Click On Add Remark Mailing Address Link
            clientHelper.ClickElement("AddClients/AddRemarkMailingAddress");

            // Enter AddRemark Description Mailing Address
//            clientHelper.TypeText("AddClients/AddRemarkDescriptionMailingAddress", "This is testing Remark 2");


            // Click On CloseRemark Mailing Address link
      //      clientHelper.ClickElement("AddClients/CloseRemarkMailingAddress");


   //#################################  CONTACTS #############################################

            // Select Salutation
            clientHelper.Select("ContactEditSalutation", "Mr");

            // Enter First Name
            clientHelper.TypeText("EditFirstName", "Test");

            // Enter Middle Name
            //  clientHelper.TypeText("AddClients/MiddleName", "Testing");

            //Enter last name
            clientHelper.TypeText("LastNameEdit", "Tester");


            //Enter contact Eaddress
            clientHelper.Select("AddresssContactLang", "English");



            //Click On Business Details Tab
            clientHelper.ClickElement("ClickOnBusinessDetailsTab");


            //Select Merchnat type 
            clientHelper.Select("EditMerchantType", "Fuel");

            //Select Processor
            clientHelper.Select("ProcessorEDIT", "First Data North");

            //GetWebDriver().FindElement(By.XPath("//select[@id='id='ClientCompanyDetailProprietorshipState']")).SendKeys(Keys.ArrowDown);

            //Select Card Type Requested
            clientHelper.Select("CardTypeRequestEdit", "All Credit and PIN Based Debit Cards");


            //Enter MC CSIC Code
            clientHelper.TypeText("AddClients/MCCSICCode", "TEST 123");


            //Enter Total Annual Volume
            clientHelper.TypeText("AddClients/TotalAnnualVolume", "2000");


            //Enter max ticket
            clientHelper.TypeText("AddClients/MaxTicket", "12");

            //Enyter Product Description
            clientHelper.TypeText("AddClients/ProductDescription", "Testing description");

            //Select Method Of Accepting Card
            clientHelper.Select("AddClients/MethodOfSAcceptingCard", "Ecommerce");

            //Select Card Type Requested
            clientHelper.Select("AddClients/montlyCardProcessingVoume", "0 - $5,000");

            //Enter Averagemerican Express Ticket
            clientHelper.TypeText("AddClients/AveragemericanExpressTicket", "AZ0001");

            //Enter Close NPC Existing MID
            clientHelper.TypeText("AddClients/CloseNPCExistingMID", "Test 20/11/15");


            //Click Additional Location
            clientHelper.ClickElement("AddClients/AdditionalLocation");

            //Click on Processor Change
            clientHelper.ClickElement("AddClients/ProcessorChange");


            //############################## PROCESSING PERCENTAGE      ###########################################


            //Enter Swipe Key In 
            clientHelper.TypeText("AddClients/SwipeKeyIn", "30");


            //Enter Swipe MO
            clientHelper.TypeText("AddClients/SwipeMO", "30");


            //Enter Swipe TO 
            clientHelper.TypeText("AddClients/SwipeTo", "30");


            //Enter Swipe Interest
            clientHelper.TypeText("AddClients/SwipeInternet", "10");

            //Enter Total Sale Busines To Business
            clientHelper.TypeText("AddClients/TotalSaleBusinesToBusiness", "45");


            //Enter Business To Consumer
            clientHelper.TypeText("AddClients/BusinessToConsumer", "55");


            //Enter Bank Card sale Business To Busines
            clientHelper.TypeText("AddClients/BankCardsaleBusinessToBusines", "50");


            //Enter Bank Crd Business To Consumer
            clientHelper.TypeText("AddClients/BankCrdBusinessToConsumer", "50");


            //Enter American Expres1. percent Swipied
            clientHelper.TypeText("AddClients/AmericanExpres1.percentSwipied", "55");

            //Enter American Expres1. percentage kEYWRD
            clientHelper.TypeText("AddClients/AmericanExpresskEYWRD", "45");

            //############################ BUSINESS SEASONABLITY  #########################################


            //Click on Is business seasonal Expand button
            clientHelper.ClickElement("AddClients/ClickBusinesSeasonabiltyExpandbtn");

            //Select Is business seasonal
            //                 clientHelper.Select("AddClients/IsBusinessSeasonal", "Yes");

            //Select Is business seasonal
            clientHelper.Select("AddClients/SeasonStart", "February");


            //Select Is business seasonal
            clientHelper.Select("AddClients/SeasonEnd", "October");


            //###################  Business Length Data   #############################################


            //Click on Business Length DataExpand Btn
            clientHelper.ClickElement("AddClients/BusinesLengthDataExpandBtn");

            //Click on Business Start Date
            clientHelper.ClickElement("AddClients/BusinessStartDate");


            //Click on Business Start datePicker ClickNxt button
            clientHelper.ClickElement("AddClients/BusinessStartdteClickNxt");


            //Click Select Start Date
            clientHelper.ClickElement("AddClients/SelectStartDate");

            //Enter Year  in Business 
            clientHelper.TypeText("AddClients/BusinessIyear", "2013");


            //################################# Card Types Accepted #############################################

            /*
                             //Click Card Type Expected Expand Btn
                             clientHelper.ClickElement("AddClients/CardTypeExpectedExpandBtn");


                             //Master Card
                             clientHelper.ClickElement("McCreditCardBT");

                             //Visa  Card
                             clientHelper.ClickElement("VisaCreditTransaction");

                             //Discover Network 
                             clientHelper.ClickElement("DiscoverNetworknONpIN");       */


            //############################ BUSINESS BANKING ACCOUNT    #################################################3

            //Click on Expand button 
            clientHelper.ClickElement("BusinessBankingDetailExpandBtn");

            //Enter Singer title
            //     clientHelper.TypeText("BankSingerTitle","TESTER");

            //Select Bank Verification 
            clientHelper.Select("BankVerificationAttached", "Voided Imprinted Business Check");

            //Enter financial Institution
            clientHelper.TypeText("FinancilInstitutionBBA", "TEST INSITITUTION");

            //AccountType
            clientHelper.Select("AccountType", "SALES");

            //DDA Account Type
            clientHelper.Select("DDAAccountType", "Checking");

            //Enter BBA AddressLine 1 
            clientHelper.TypeText("BBAAddressLine1", "TEST INSITITUTION");


            //Enter BBA Addreessline 2
            clientHelper.TypeText("BBAAddreessline2", "TEST INSITITUTION");

            // Enter BBACity
            clientHelper.TypeText("BBACity", "TEST CITY");

            //Select Country
            clientHelper.Select("BusinessCountry", "Canada");
            clientHelper.WaitForWorkAround(3000);

            //Select BBA State
            clientHelper.Select("BBBAState", "BC");

            //Enter BBA Contact Name
            clientHelper.TypeText("BBAContactName", "TMR TEST");

            //Enter BBA Contact Phone
            clientHelper.TypeText("BBAContactPhone", "1234566788");

            //Enter BBA Account Number
            clientHelper.TypeText("BBAAccountNumber", "78787788");


            //Click on Montly checkbox
            clientHelper.ClickElement("BBAMontlyBilling");


            //BBA Deposite Time Frame
            clientHelper.Select("BBADepositeTimeFrame", "Premium ACH");

            //###########################   COMPLIANCE  INFORMATION   ################################################

            //Click on Compliane Information 
            clientHelper.ClickElement("ClickOnExpandBtnComplianInfrmation");

            //Select Third Party Gateway
            clientHelper.Select("ThirdPartyGateway", "Application");

            //Click on Are you compliant with the Payment Card Industry Data Security Standards? checkbox
            clientHelper.ClickElement("PaymentCardInfoCheckBox");

            //Select last certificate date
            clientHelper.TypeText("LastCertificationDate", "2015-03-17");

            //Click on Do you store cardholder data? Paper checkbox
            clientHelper.ClickElement("DoyouStoreCardHolderData");

            //Click on DoYouStoreCardHolderElectronic check box
            clientHelper.ClickElement("DoYouStoreCardHolderElectronic");

            // Click on Merchant data to which this vendor has access
            clientHelper.ClickElement("MerchantDataVenderAccess");


            // Click on Merchant data to which this vendor has access
            clientHelper.ClickElement("ThirdPartySoftwareAddress");


            //Click on Third Party Software contact information
            clientHelper.ClickElement("ThirdPartySoftwareContactInformation");


//#####################   Rate And Fees

            //Click on Rates and Fees tab
            updateRateFees.ClickElement("ClickOnRateFeesTab");

            //Select Processor
            clientHelper.Select("AddClients/Processor", "First Data North");
            Thread.Sleep(5000);

            //Select Merchant Type
            GetWebDriver().FindElement(By.XPath("//select[@id='ClientRatesFeeIndustry']")).SendKeys(Keys.ArrowDown);

            //Enter MCC/SIC Code
            updateRateFees.TypeText("EnterMCCSICcODE", "TEST");

            Thread.Sleep(5000);
            //Select Discount Frequency
            clientHelper.Select("AddClients/DiscountFrequency", "Daily");


            //Select Debit Network InterFace Pass Through
            updateRateFees.Select("DebitNetworkInterFacePassThrough", "Yes");

            //Enter Vica Credit Oualified Percentage
            updateRateFees.TypeText("VicaCreditOualifiedPercentage", "30");

            //Enter Vica Credit Mid Qualified
            updateRateFees.TypeText("VicaCreditMidQualified", "30");

            //Enter Vica Credit Authorization Fees
            updateRateFees.TypeText("VicaCreditAuthorizationFees", "30");

            //Enter Vica Check Card Qualified
            updateRateFees.TypeText("VicaCheckCardQualified", "30");

            //Enter Vica CheckCard Mid Qualified
            updateRateFees.TypeText("VicaCheckCardMidQualified", "30");

            //Enter Vica CheckCard Non Qualified
            updateRateFees.TypeText("VicaCheckCardNonQualified", "30");


            //Enter Vica Check Card Per Item
            updateRateFees.TypeText("VicaCheckCardPerIthem", "30");


            //Enter Vica Check Card Mid Qual Per Item
            updateRateFees.TypeText("VicaCheckCardMidQualPerItem", "30");


            //Enter Vice Check Card Non Qual Per item
            updateRateFees.TypeText("ViceCheckCardNonQualPeritem", "30");


            //Enter Authentication Fees
            updateRateFees.TypeText("AuthenticationFees", "30");


            //Enter Master Card Credit Qualified
            updateRateFees.TypeText("MasterCardCreditQualified", "30");


            //Enter Master Card Credit Non Qualified
            updateRateFees.TypeText("MasterCardCreditNonQualified", "30");

            //Enter Master Card Credit PerItem
            updateRateFees.TypeText("MasterCardCreditPerItem", "30");


            //Enter Master Credit Card MidQual PerItem
            updateRateFees.TypeText("MasterCreditCardMidQualPerItem", "30");


            //Enter Master Credit Card Non Qual Per Item
            updateRateFees.TypeText("MasterCreditCardNonQualPerItem", "30");

            //Enter Master Credit Card Authentication fee
            updateRateFees.TypeText("MasterCreditCardAuthenticationfee", "30");

            // ############################     MASTER DEBIT CARD   ###########################################

            //Enter Master Card Debit Qualified
            updateRateFees.TypeText("MasterCardDebitQualified", "30");


            //Enter Master Credit Card Mid Qualified
            updateRateFees.TypeText("MasterCreditCardMidQualified", "30");

            //Enter Master Debit Card Non Qualified
            updateRateFees.TypeText("MasterDebitCardNonQualified", "30");


            //Enter Master Debit Card perItem
            updateRateFees.TypeText("MasterDebitCardperItem", "30");


            //Enter Master Debit Card MidQual
            updateRateFees.TypeText("MasterDebitCardMidQual", "30");

            //Enter Master Debit Card Non Qual PerItem
            updateRateFees.TypeText("MasterDebitCardNonQualPerItem", "30");


            //Enter Master Debit Card Authorization Fees
            updateRateFees.TypeText("MasterDebitCardAuthorizationFees", "30");


            // ############################     Discover Network Credit  ###########################################

            //Enter Discover NetworK Credit Qualified
            updateRateFees.TypeText("DiscoverNetworCreditQualified", "30");


            //Enter Discover Mid Qualified
            updateRateFees.TypeText("DiscoverMidQualified", "30");

            //Enter Discover Network Credit NonQualified
            updateRateFees.TypeText("DiscoverNetworkCreditNonQualified", "30");


            //Enter Discover Network Credit PerItem
            updateRateFees.TypeText("DiscoverNetworkCreditPerItem", "30");


            //Enter Discover Network Credit Mid Qualified
            updateRateFees.TypeText("DiscoverNetworkCreditMidQualified", "30");

            //Enter Discover Network Credit Non Qualified
            updateRateFees.TypeText("DiscoverNetworkCreditNonQualified", "30");


            //Enter Discover Network credit Authentication
            updateRateFees.TypeText("DiscoverNetworkcreditAuthentication", "30");


            // ############################     Discover Network Debit   ###########################################

            //Enter Discover Network Debit Qualified
            updateRateFees.TypeText("DiscoverNetworkDebitQualified", "30");


            //Enter Discover Network Debit Mid Qualified
            updateRateFees.TypeText("DiscoverNetworkDebitMidQualified", "30");

            //Enter Discover Network Debit Non Qualified
            updateRateFees.TypeText("DiscoverNetworkDebitNonQualified", "30");


            //Enter Discover Network Debit PerItem
            updateRateFees.TypeText("DiscoverNetworkDebitPerItem", "30");


            //Enter Discover Network Debit Mid QualPerItem
            updateRateFees.TypeText("DiscoverNetworkDebitMidQualPerItem", "30");

            //Enter Discover Network Debit Non QualPerItem
            updateRateFees.TypeText("DiscoverNetworkDebitNonQualPerItem", "30");


            //Enter Discover Network Debit Authentication
            updateRateFees.TypeText("DiscoverNetworkDebitAuthentication", "30");


            // ############################     American Express   ###########################################

            //Enter American Express Qualified
            updateRateFees.TypeText("AmericanExpressQualified", "30");


            //Enter American Express Mid Qualified 
            updateRateFees.TypeText("AmericanExpressMidQualified", "30");

            //Enter American Express Debit Non Qualified
            updateRateFees.TypeText("AmericanExpressDebitNonQualified", "30");


            //Enter American Express Debit PerItem
            updateRateFees.TypeText("AmericanExpressDebitPerItem", "30");


            //Enter American Express Debit Mid QualPerItem
            updateRateFees.TypeText("AmericanExpressDebitMidQualPerItem", "30");

            //Enter American Express Debit Non Qual PerItem
            updateRateFees.TypeText("AmericanExpressDebitNonQualPerItem", "30");


            //Enter American Express Debit Authentication
            updateRateFees.TypeText("AmericanExpressDebitAuthentication", "30");


            //#######################################  AMEX Prepaid   ################################################

            //Enter AMEX Prepaid Qualified
            updateRateFees.TypeText("AMEXPrepaidQualified", "50");


            //Enter American Express Debit Authentication
            updateRateFees.TypeText("AMEXPrepaidMidQualified", "50");


            //##########################################  Amex Monthly Flat Fee   ##############################################

            //Select Amex Monthly Flat Fee
            updateRateFees.Select("AmexMonthlyFlatFee", "Yes");

            //########################################## Visa Regualted Debit  #####################################################3

            //Enter Visa Regualted Debit
            updateRateFees.TypeText("VisaRegulatedDebit", "20");


            //Enter Visa Regualted Debit
            updateRateFees.TypeText("VisaRegulatedDebitPerItem", "20");


            //################################ MasterCard Regulated Debit   #######################################################

            //Enter MasterCard Regulated Debit Qualified
            updateRateFees.TypeText("VisaRegulatedDebit", "20");


            //Enter MasterCard Regulated Debit Per Item
            updateRateFees.TypeText("VisaRegulatedDebitPerItem", "20");


            //################################ Discover Network Regulated Debit  #######################################################

            //Enter Discover Network Regulated Debit
            updateRateFees.TypeText("DiscoverNetworkRegualtedDebit", "20");

            //Enter Discover Network Regulated Debit Per Item
            updateRateFees.TypeText("DiscoverNetworkRegulatedDebitPerItem", "20");

            //######################################## Diners Club / Carte Blanche    ###########################################################

            //Enter Diners Club / Carte Blanche
            updateRateFees.TypeText("DinerClubCareteQualified", "20");

            //Enter Diners Club / Carte Blanche Per
            updateRateFees.TypeText("DinerClubQualPer", "20");

            //Enter Diners Club / Carte Blanche
            updateRateFees.TypeText("DinerAuthentication", "20");

            //####################################   Discover   ################################################################

            //Enter Discover
            updateRateFees.TypeText("DiscoverQualifiedQualified", "20");

            //Enter Discover
            updateRateFees.TypeText("DiscoverPerItem", "20");

            //Enter Discover
            updateRateFees.TypeText("DiscoverAuthentictaion", "20");

            //###############################   EBT   ####################################################

            //Enter Discover
            updateRateFees.TypeText("EBTQualified", "20");

            //Enter Discover
            updateRateFees.TypeText("EBTItem", "2000");

            //###############################   EBT CASH BENEFITS  ####################################################

            //Enter EBT Cash Benefit Qualified
            updateRateFees.TypeText("EBTCashBenefitQualified", "20");

            //###############################   Flexcache (Gift Card)   ####################################################

            //Enter Flex Cache Gift Card
            updateRateFees.TypeText("FlexCacheGiftCard", "20");

            //Enter Flex Cache Per Gift Card
            updateRateFees.TypeText("FlexCachePerGiftCard", "20");

            //Enter Flex Cache Authentication GiftCard
            updateRateFees.TypeText("FlexCacheAuthenticationGiftCard", "20");

            // ############################     JCB    ###########################################

            //Enter JCB  Qualified
            updateRateFees.TypeText("JCBQualified", "30");


            //Enter JCB Mid Qualified
            updateRateFees.TypeText("JCBMidQualified", "30");

            //Enter JCB Non Qualified 
            updateRateFees.TypeText("JCBNonQualified", "30");


            //Enter JCB Per Item 
            updateRateFees.TypeText("JCBPerItem", "30");


            //Enter JCB Mid Qual Per Item
            updateRateFees.TypeText("JCBMidQualPerItem", "30");

            //Enter JCB Non Qual PerItem
            updateRateFees.TypeText("JCBNonQualPerItem", "30");


            //Enter JCB Authentication
            updateRateFees.TypeText("JCBAuthentication", "30");


            // ############################     PIN BASED DEBIT    ###########################################

            //Enter PIN BASED DEBIT
            updateRateFees.TypeText("PinBasedDebitQualified", "30");


            //Enter Pin Based Debit Mid Qualified
            updateRateFees.TypeText("PinBasedDebitMidQualified", "30");

            //Enter Pin Based DebitPer Qualified
            updateRateFees.TypeText("PinBasedDebitPerQualified", "30");


            // ############################     Wright Express Fleet Card     ###########################################

            //Enter Wright Express Fleet Card Qualified
            updateRateFees.TypeText("WrightExpressFleetCardQualified", "30");


            //Enter Wright Express Fleet Card Mid Qualified
            updateRateFees.TypeText("WrightExpressFleetCardMidQualified", "30");

            //Enter Wright Express Fleet Card Non Qualified
            updateRateFees.TypeText("WrightExpressFleetCardNonQualified", "30");


            //Enter Wright Express Fleet Card Per Item
            updateRateFees.TypeText("WrightExpressFleetCardPerItem", "30");


            //Enter Wright Express Fleet Card Mid Qual Per Item
            updateRateFees.TypeText("WrightExpressFleetCardMidQualPerItem", "30");

            //Enter JCB Wright Express Fleet Card Non Qual Per Item
            updateRateFees.TypeText("WrightExpressFleetCardNonQualPerItem", "30");


            //Enter Wright Express FleetCard Authentication
            updateRateFees.TypeText("WrightExpressFleetCardAuthentication", "30");


            // ############################    Voyager Fleet Card      ###########################################

            //Enter Voyager Fleet Card Qualified
            updateRateFees.TypeText("VoyagerFleetCardQualified", "30");


            //Enter Voyager Fleet Card Mid Qualified
            updateRateFees.TypeText("VoyagerFleetCardMidQualified", "30");

            //Enter Voyager Fleet Card Non Qualified
            updateRateFees.TypeText("VoyagerFleetCardNonQualified", "30");


            //Enter Voyager Fleet Card Per Item
            updateRateFees.TypeText("VoyagerFleetCardPerItem", "30");


            //Enter Voyager Fleet Card Mid Qual PerItem
            updateRateFees.TypeText("VoyagerFleetCardMidQualPerItem", "30");

            //Enter Voyager Fleet Card Non Qual Per Item
            updateRateFees.TypeText("VoyagerFleetCardNonQualPerItem", "30");


            //Enter Voyager Fleet Card Authentication
            updateRateFees.TypeText("VoyagerFleetCardAuthentication", "30");


            //####################################  BILBACK SUURCHARGE #######################################

            //Enter BillBack Surcharge Qualified
            updateRateFees.TypeText("BillBackSurchargeQualified", "30");

            //################################### Rewards Surcharge (Retail Only)  ############################

            //Enter Rewards Surcharge Retail Qualified
            updateRateFees.TypeText("RewardsSurchargeRetailQualified", "30");

            //Click Rewards Surcharge With Qualified Reward At Pass
            updateRateFees.ClickElement("RewardsSurchargeWithQualifiedRewardAtPass");

            //####################################  MC Worldcard  #######################################

            //Enter Mc World Card Qualified
            updateRateFees.TypeText("McWorldCardQualified", "30");

            //Enter Mc World Card Mid Qualified
            updateRateFees.TypeText("McWorldCardMidQualified", "30");


            //Enter Mc World Card Non Qualified
            updateRateFees.TypeText("McWorldCardNonQualified", "30");


            //Enter Mc World Card Per Item
            updateRateFees.TypeText("McWorldCardPerItem", "30");


            //Enter Mc World Card Mid Qual PerItem
            updateRateFees.TypeText("McWorldCardMidQualPerItem", "30");

            //Enter Mc World Card Qualified
            updateRateFees.TypeText("McWorldCardNonQualPerItem", "30");

            //####################################  Visa Rewards1 #######################################

            //Enter Visa Rewards Qualified
            updateRateFees.TypeText("VisaRewardsQualified", "30");

            //Enter Visa Rewards Mid Qualified
            updateRateFees.TypeText("VisaRewardsMidQualified", "30");

            //#######################################  MC Other Item  ##################################################

            //Enter Mc Other Item qualified
            updateRateFees.TypeText("McOtherItemqualified", "30");

            //#######################################  Visa Other Item  ##################################################

            //Enter Visa Other Item
            updateRateFees.TypeText("VisaOtherItem", "30");

            //#######################################  DiscoverOtherItem #######################################

            //Enter Discover Other Item
            updateRateFees.TypeText("DiscoverOtherItem", "30");

            //################################### JBC OTHER ITEM   #####################################

            //Enter JBC Other Item 
            updateRateFees.TypeText("JBCOtherItem", "30");

            //##################################### AMEX OTHER ITEM   ######################################

            //Enter AMEX Other Item
            updateRateFees.TypeText("AMEXOtherItem", "30");

            //##################################### PIN Debit-Other Volume Percentage  ###########################

            //Enter PIN Debit-Other Volume Percentage
            updateRateFees.ClickElement("DuesAssesmentCheckbox");


            //################################   OTHER SERVICE FEES    #####################################################


            //Click On Click On Expand Button
            updateRateFees.ClickElement("ClickOnOtherServiceFeeExpandButton");

            //Enter Account Setup Fee
            //            updateRateFees.TypeText("AccountSetupFee", "30");

            //Select Account Setup Frequency
            updateRateFees.Select("AccountSetupFrequency", "daily");

            //Enter ACH Return Item Processing
            updateRateFees.TypeText("ACHReturnItemProcessing", "30");

            //Select ACH Return Item Processing Frequency
            updateRateFees.Select("ACHReturnItemProcessingFrequency", "daily");


            //Enter Annual MemberShip
            updateRateFees.TypeText("AnnualMemberShip", "30");

            //Select Annual Member Ship Frequency
            updateRateFees.Select("AnnualMemberShipFrequency", "daily");


            //Enter Annual Fees Collected Month
            updateRateFees.Select("AnnualFeesCollectedMonth", "January");

            //Select Application Processing
            updateRateFees.TypeText("ApplicationProcessing", "30");


            //Enter Application Processing Frquency
            updateRateFees.Select("ApplicationProcessingFrquency", "daily");

            //Select Application Processing
            updateRateFees.TypeText("ApplicationProcessing", "30");


            //Enter Application Processing Frquency
            updateRateFees.Select("ApplicationProcessingFrquency", "daily");


            //Select Batch Settlement
            updateRateFees.TypeText("BatchSettlement", "30");


            //Enter Batch Settlement Frequency
            updateRateFees.Select("BatchSettlementFrequency", "daily");


            //Enter Charge Back Processing
            updateRateFees.TypeText("ChargeBackProcessing", "30");

            //Select ChargeBackFrequency
            updateRateFees.Select("ChargeBackFrequency", "daily");

            //Enter Account Setup Fee
            updateRateFees.TypeText("DebitEBTSetUp", "30");

            //Select Debit EBT Frequency
            updateRateFees.Select("DebitEBTFrequency", "daily");


            //Enter Decisionable Data
            updateRateFees.TypeText("DecisionableData", "30");

            //Select Decisionable Data Frequency
            updateRateFees.Select("DecisionableDataFrequency", "daily");


            //Enter Deposit Confirmation Letter
            updateRateFees.TypeText("DepositConfirmationLetter", "30");

            //Select Deposit Confirmation Freq
            updateRateFees.Select("DepositConfirmationFreq", "daily");


            //Enter Excepetion Item Respond
            updateRateFees.TypeText("ExcepetionItemRespond", "30");

            //Select Excepetion Item Respond Frequency
            updateRateFees.Select("ExcepetionItemRespondFrequency", "daily");

            //Enter Flex Cache Setup
            updateRateFees.TypeText("FlexCacheSetup", "30");

            //Select Flex Cache Setup Frequency
            updateRateFees.Select("FlecCacheSetupFrequency", "daily");


            //Enter Flex Cache Internal Store Settlement
            updateRateFees.TypeText("FlexCacheInternalStoreSettlement", "30");

            //Select Flex Cache Internal Store Settlement Frequency
            updateRateFees.Select("FlexCacheInternalStoreSettlementFrequency", "daily");


            //Enter Monthly Cutomer Service Fees
            updateRateFees.TypeText("MonthlyCutomerServiceFees", "30");

            //Enter E Marchent View Access Fee
            updateRateFees.TypeText("EMarchentViewAccessFee", "30");

            //Enter MonthlySupplies
            updateRateFees.TypeText("MonthlySupplies", "30");

            //Enter Other Monthly Fees
            updateRateFees.TypeText("OtherMonthlyFees", "30");

            //Enter Other Fees
            updateRateFees.TypeText("OtherFees", "30");


            //Enter VisaMisuesFees
            updateRateFees.TypeText("VisaMisuesFees", "30");


            //Enter MCCNPAVSFees
            updateRateFees.TypeText("MCCNPAVSFees", "30");

            //Enter Discover Data Usage
            updateRateFees.TypeText("DiscoverDataUsage", "30");

            //Enter Acquire Processing Fees Debit
            updateRateFees.TypeText("AcquireProcessingFeesDebit", "30");

            //Enter MC License Volume Fee
            updateRateFees.TypeText("MCLicenseVolumeFee", "30");

            //Enter VisaMisuesFees
            updateRateFees.TypeText("VisaPartialAuth", "30");

            //Enter Trans Freedom Montly Fee
            updateRateFees.TypeText("TransFreedomMontlyFee", "30");

            //Enter Monthly Merchant Club Fees
            updateRateFees.TypeText("MonthlyMerchantClubFees", "30");

            //Enter Reprogramming Fee
            updateRateFees.TypeText("ReprogrammingFee", "30");


            //Enter Visa Transaction Interigity Fee
            updateRateFees.TypeText("VisaTransactionInterigityFee", "30");


            //Enter Visa Kilobyte Surcharge Fee
            updateRateFees.TypeText("VisaKilobyteSurchargeFee", "30");


            //Enter MC AVS Surchage Fee
            updateRateFees.TypeText("MCAVSSurchageFee", "30");

            //Enter Visa AFD Non Participation
            updateRateFees.TypeText("VisaAFDNonParticipation", "30");

            //Enter MC Kilobyte Surcharge Fee
            updateRateFees.TypeText("MCKilobyteSurchargeFee", "30");

            //Enter MC Digital Enable Fee
            updateRateFees.TypeText("MCDigitalEnableFee", "30");

            //Enter Discover Auth Surchage
            updateRateFees.TypeText("DiscoverAuthSurchage", "30");


            //Enter Star Debit Network Anual Surcharge
            updateRateFees.TypeText("StarDebitNetworkAnualSurcharge", "30");

            //Enter Jeanie Debit Network Anual Surcharge
            updateRateFees.TypeText("JeanieDebitNetworkAnualSurcharge", "30");

            //Enter Protfolio Msg Fees
            updateRateFees.TypeText("ProtfolioMsgFees", "30");

            //Enter Clover And Transarmor MontlyFee
            updateRateFees.TypeText("CloverAndTransarmorMontlyFee", "30");

            //Enter Apriva Activation Fee
            updateRateFees.TypeText("AprivaActivationFee", "30");

            //Enter Perka Solution Fee
            updateRateFees.TypeText("PerkaSolutionFee", "30");

            //Enter Other Services Fees
            updateRateFees.TypeText("OtherServicesFees", "30");


            //Enter On File Fee
            updateRateFees.TypeText("OnFileFee", "30");


            //Enter PCI Fee Year
            updateRateFees.TypeText("PCIFeeYear", "30");

            //Enter Paper Statement Fee
            updateRateFees.TypeText("PaperStatementFee", "30");

            //Enter Visa Processing Fee
            updateRateFees.TypeText("VisaProcessingFee", "30");

            // ######################3#####################   RIGHT SIDE OF OTHER SERVICES FEES


            //Enter Frame Relay Setup
            updateRateFees.TypeText("FrameRelaySetup", "30");

            //Select Frame Relay Frequency
            updateRateFees.Select("FrameRelayFrequency", "daily");

            //Enter Minimum Montly Discount
            updateRateFees.TypeText("MinimumMontlyDiscount", "30");

            //Select Minimum Montly discount Frequency
            updateRateFees.Select("MinimumMontlyDiscountFrequency", "daily");


            //Enter Monthly Service Support 
            updateRateFees.TypeText("MonthlyServiceSupport", "30");

            //Select Montly Service Support freq
            updateRateFees.Select("MontlyServiceSupportfreq", "daily");


            //Enter Net Connect Activation
            updateRateFees.TypeText("NetConnectActivation", "30");

            //Select Net Connect Activation Frequency
            updateRateFees.Select("NetConnectActivationFrequency", "daily");


            //Enter Orbital GateWay Activation
            updateRateFees.TypeText("OrbitalGateWayActivation", "30");

            //Select Orbital GateWay Activation Frequency
            updateRateFees.Select("OrbitalGateWayActivationFrequency", "daily");


            //Enter Orbital Montly Service Support
            updateRateFees.TypeText("OrbitalMontlyServiceSupport", "30");

            //Select Orbital Montly Service Support Frequency
            updateRateFees.Select("OrbitalMontlyServiceSupportFrequency", "daily");


            //Enter Pin Pad Encrypytion
            updateRateFees.TypeText("PinPadEncrypytion", "30");

            //Select Pin Pad Encrypytion Frequency
            updateRateFees.Select("PinPadEncrypytionFrequency", "daily");

            //Enter Recon Solution
            updateRateFees.TypeText("ReconSolution", "30");

            //Select Recon Solution Frequecy
            updateRateFees.Select("ReconSolutionFrequecy", "daily");

            //Enter Retrivel
            updateRateFees.TypeText("Retrivel", "30");

            //Select Retrivel Frequency
            updateRateFees.Select("RetrivelFrequency", "daily");

            //Enter Statement
            updateRateFees.TypeText("Statement", "30");

            //Select StatementFrequency
            updateRateFees.Select("StatementFrequency", "daily");

            //Enter WirelessActivation
            updateRateFees.TypeText("WirelessActivation", "30");

            //Select Wireless Activation Frequency
            updateRateFees.Select("WirelessActivationFrequency", "daily");

            //Enter Wireless Montly Service Support
            updateRateFees.TypeText("WirelessMontlyServiceSupport", "30");

            //Select Wireless Montly Service Support Frequecy
            updateRateFees.Select("WirelessMontlyServiceSupportFrequecy", "weekly");


            //Enter Monthly Debit Access Fees
            updateRateFees.TypeText("MonthlyDebitAccessFees", "30");

            //Enter Early Termination Fees
            updateRateFees.TypeText("EarlyTerminationFees", "30");

            //Enter Description
            updateRateFees.TypeText("Descriptionl", "30");

            //Enter MC Acquirier AVS Billing
            updateRateFees.TypeText("MCAcquirierAVSBilling", "30");

            //Enter MC Processing Integration
            updateRateFees.TypeText("MCProcessingIntegration", "30");

            //Enter Visa Network Fees
            updateRateFees.TypeText("VisaNetworkFees", "30");

            //Enter Visa Network Fes CNP
            updateRateFees.TypeText("VisaNetworkFesCNP", "30");

            //Enter Terminal Support Fees
            updateRateFees.TypeText("TerminalSupportFees", "30");

            //Enter Start Date
            updateRateFees.TypeText("StartDate", "2015-03-24");

            //Enter Network Realse Fees
            updateRateFees.TypeText("NetworkRealseFees", "40");

            //Enter Discover International Services Fees
            updateRateFees.TypeText("DiscoverInternationalServicesFees", "40");

            //Enter Visa Kilo byte Fees Surcharge
            updateRateFees.TypeText("VisaKilobyteFeesSurcharge", "40");

            //Enter MCC VC2 Fees Surcharge
            updateRateFees.TypeText("MCCVC2FeesSurcharge", "40");

            //Enter Visa FAND Card Not Present Surcharge
            updateRateFees.TypeText("VisaFANDCardNotPresentSurcharge", "40");

            //Enter MC Kilo Byte Fee Surcharge
            updateRateFees.TypeText("MCKiloByteFeeSurcharge", "40");

            //Enter AMEX Network Surcharge Fees
            updateRateFees.TypeText("AMEXNetworkSurchargeFees", "40");


            //Enter Discover Network Au Fee Surcharge
            updateRateFees.TypeText("DiscoverNetworkAutFeeSurcharge", "40");

            //Enter Pulse Debit Card Annual Surcharge
            updateRateFees.TypeText("PulseDebitCardAnnualSurcharge", "40");

            //Enter Return Trans Fees
            updateRateFees.TypeText("ReturnTransFees", "40");

            //Enter eIDS Acces Fees
            updateRateFees.TypeText("eIDSAccesFees", "40");

            //Enter Insights Solution Monthly fee
            updateRateFees.TypeText("InsightsSolutionMonthlyfee", "40");

            //Enter Apriva Montly Acces Fes
            updateRateFees.TypeText("AprivaMontlyAccesFes", "40");

            //Enter Description Again
            updateRateFees.TypeText("DescriptionAgain", "40");

            //Enter Description Freq Select
            updateRateFees.Select("DescriptionFreSelect", "Per Item");

            //SelectMonthly
            updateRateFees.Select("SelectMontly", "January");

            //Enter Advantage Buyer Program
            updateRateFees.TypeText("AdvantageBuyerProgram", "40");

            //Enter PCI Fees Month
            updateRateFees.TypeText("PCIFeesMonth", "40");

            //Enter MC proceesing Fees
            updateRateFees.TypeText("MCproceesingFees", "60");


            //###############################################   OTHER AUTHOROIAZATION FEES  ######################################


            //Enter Click On Expand Btn OTHER AUTHOROIAZATION FEES
            updateRateFees.ClickElement("ClickOnExpandBtnOAF");


            //Enter MC proceesing Fees
            updateRateFees.TypeText("Voice", "60");


            //Enter Frame Relay Authoriztion
            updateRateFees.TypeText("FrameRelayAuthoriztion", "60");


            //Enter MC NABU Fees
            updateRateFees.TypeText("MCNABUFees", "60");


            //Enter Cross Border Fees
            updateRateFees.TypeText("CrossBorderFees", "60");


            //Enter Issuer Refferal
            updateRateFees.TypeText("IssuerRefferal", "60");


            //Enter Net Connect Authorization
            updateRateFees.TypeText("NetConnectAuthorization", "60");


            //Enter Visa APF Fees
            updateRateFees.TypeText("VisaAPFFees", "60");

            //Enter Cross Border FeesUs
            updateRateFees.TypeText("CrossBorderFeesUs", "60");

            //Enter Electronic AVS
            updateRateFees.TypeText("ElectronicAVS", "60");

            //Enter OAF WireLess Authorization Fees
            updateRateFees.TypeText("OAFWireLessAuthorizationFees", "60");

            //Enter OAF Zero Limit Fee
            updateRateFees.TypeText("OAFZeroLimitFee", "60");

            //Enter Connectivity Fees
            updateRateFees.TypeText("ConnectivityFees", "60");

            //Enter Visa Inter National Fees
            updateRateFees.TypeText("VisaInterNationalFees", "60");

            //Enter TransArmorAuthfees
            updateRateFees.TypeText("TransArmorAuthfees", "60");

            //Enter Visa Bin Fees
            updateRateFees.TypeText("VisaBinFees", "60");


            //Enter MC IICA Fees
            updateRateFees.TypeText("MCIICAFees", "60");

            //Enter Regulatory Product Fee
            updateRateFees.TypeText("RegulatoryProductFee", "60");

            //Enter TINTNF Invalid Fee
            updateRateFees.TypeText("TINTNFInvalidFee", "60");

            //Enter Web site Usage Fees
            updateRateFees.TypeText("WebsiteUsageFees", "60");

            //Enter IVR Usage Fees
            updateRateFees.TypeText("IVRUsageFees", "60");

            //Enter MC LiceNse Fee
            updateRateFees.TypeText("MCLiceseFee", "60");

            //Enter MC License Fees Sale Vol
            updateRateFees.TypeText("MCLicenseFeesSaleVol", "60");


            //Enter MC License Fees Flat Rate  
            updateRateFees.TypeText("MCLicenseFeesFlatRate", "60");

            //Select MCLicenseFeesColectType
            updateRateFees.Select("SelectMCLicenseFeesColectType", "Monthly");

            //################################ MERCHANT OPTION   ##############################################


            //Select AutoClose
            updateRateFees.Select("AutoClose", "n/a");

            //Select Apply ServiceType
            updateRateFees.Select("ApplyServiceType", "One Point/Full Service");

            //Select Accept Tips
            updateRateFees.Select("AcceptTips", "Yes");

            //Select HaveYouAmricanExpresSENumb
            updateRateFees.Select("HaveYouAmricanExpresSENumb", "n/a");


            //###################################   APPLY FOR CASH ADVANCE    #############################################


            //Click on Checkbox
            updateRateFees.ClickElement("ClickOnCheckBoxCasdAdvance");

            //Select Type Cash Adv
            updateRateFees.Select("TypeCashAdv", "Loan");

            //Enter Intended Use Of Fund  
            updateRateFees.TypeText("IntendedUseOfFund", "60");

            //Enter Time With Current Processor 
            updateRateFees.TypeText("TimeWithCurrentProcessor", "60");

            //Enter Requested Advance Fund
            updateRateFees.TypeText("RequestedAdvanceFund", "60");

            //Click on Is Business Sale Radio button
            updateRateFees.ClickElement("IsBusinessSale");

            //Click on  Do You Have Federal
            updateRateFees.ClickElement("DoYouHaveFederal");


            //###########################  GATEWAY FEES   ##########################################

            //CLICK ON GATEWAY FEE EXPEND BUTTON
            updateRateFees.ClickElement("ClickGatewyaExpndbtn");

            //Enter Gateway Fee
            updateRateFees.TypeText("GatewayFees", "600");

            //Enter Gateway Software License
            updateRateFees.TypeText("GatewaySoftwareLicense", "10020");

            //Enter Annual License Fees
            updateRateFees.TypeText("AnnualLicenseFees", "800");

            //Enter Gate Way Transactionfee
            updateRateFees.TypeText("GateWayTransactionfee", "300");

            //Enter GateWay SetUp Fee
            updateRateFees.TypeText("GateWaySetUpFee", "200");


            //############################ CHECK PROCESSING RATES   #################################################


            //Click On Check Processing Rate Expnd Btn
            updateRateFees.ClickElement("ClickOnCheckProcessingRateExpndBtn");

            //Enter Check Discount Rate
            updateRateFees.TypeText("CheckDiscountRate", "600");

            //Enter CheckSetUpFee
            updateRateFees.TypeText("CheckSetUpFee", "10020");

            //Enter Check Monthly Minimum
            updateRateFees.TypeText("CheckMonthlyMinimum", "800");

            //Enter Check Transaction Fees
            updateRateFees.TypeText("CheckTransactionFees", "300");

            //Enter Total Number Of Checks
            updateRateFees.TypeText("TotalNumberOfChecks", "200");

            //Enter Average Check Amount
            updateRateFees.TypeText("AverageCheckAmount", "200");

            //Enter Average Check Amount
            updateRateFees.TypeText("LargestCheckAmount", "400");


            //####################### SPECIAL INSTRUCTION   ####################################

            //Click On Expand Btn Special Ins
            updateRateFees.ClickElement("ClcikOnExpandBtnSpecialIns");

            //Enter Enter Special Instruction
            updateRateFees.TypeText("EnterSpecialInstruction", "Test Instruction");


            //############################## TELECHECK   ####################################################

            //Click On Tele Check ExpndBtn
            updateRateFees.ClickElement("ClickOnTeleCheckExpndBtn");

            //Select Tele Check
            updateRateFees.Select("SelectTeleCheck", "Split Dial");

            //Enter Inquriry Rate
            updateRateFees.TypeText("InquiryRate", "100");

            //Select Rates And Fees
            updateRateFees.Select("RatesAndFees", "n/a");

            //Enter Per TXN Fees
            updateRateFees.TypeText("PerTXNFees", "90");

            //Enter Monthly Minimum Fees
            updateRateFees.TypeText("MonthlyMinimumFees", "90");


            //#############################  FIRST DATA GLOBAL GATEWAY E4 ####################################


            //Click Click On Expand Btn Of Frst Data GateWay E4
            updateRateFees.ClickElement("ClickOnExpandBtnOfFrstDatGateWayE4");

            //Click GGE4 Checkbox
            updateRateFees.ClickElement("GGE4Checkbox");

            //Enter GGE4 Effective Data
            updateRateFees.TypeText("GGE4EffectiveData", "90");

            //Enter GGE4 One Time Setup
            updateRateFees.TypeText("GGE4OneTimeSetup", "90");

            //Enter GGE4 Monthly Fee
            updateRateFees.TypeText("GGE4MonthliFee", "90");


            //Enter GGE4 Auth Fee
            updateRateFees.TypeText("GGE4AuthFee", "90");

            //Enter Pay Pal Auth Fees
            updateRateFees.TypeText("PayPalAuthFees", "90");

            //Enter PayPal Sale Fee
            updateRateFees.TypeText("PayPalSaleFee", "90");

            //Enter PayPal Return Fee
            updateRateFees.TypeText("PayPalReturnFee", "90");


            //Enter GGE4 TeleCheck Fee Deposite Fee
            updateRateFees.TypeText("GGE4TeleCheckFeeDepositeFee", "90");


            //Enter GGE4 Tele Check Adjust Fee
            updateRateFees.TypeText("GGE4TeleCheckAdjustFee", "90");

            //############################## AMEX OPT Blue  ################################################


            //Enter Amex Credit Discount Rate
            updateRateFees.TypeText("AmexCreditDiscountRate", "90");

            //Enter Credit Discount Rate 813
            updateRateFees.TypeText("CreditDiscountRate813", "90");


            //Enter Sale And Credit Trans
            updateRateFees.TypeText("SaleAndCreditTrans", "90");

            //Enter Mid Qual Credit Trans  
            updateRateFees.TypeText("MidQualCreditTrans", "90");

            //Enter Non Qual Credit Trans
            updateRateFees.TypeText("NonQualCreditTrans", "90");

            //Enter Non Qual Surcarge
            updateRateFees.TypeText("NonQualSurcarge", "90");

            //Enter Charge Back Fees
            updateRateFees.TypeText("ChargeBackFees", "90");

            //Enter Retrival Fees
            updateRateFees.TypeText("RetrivalFees", "90");

            //Enter AVS Amex
            updateRateFees.TypeText("AVSAmex", "90");

            //EnterAmex Auth Fees
            updateRateFees.TypeText("AmexAuthDees", "90");

//####################  CUSTOMER RELATIONSHIPS ###########################

            //Click on CoustomerRelationTab Tab
            customerRelationshipHelper.ClickOnButton("CoustomerRelationTab");
            Thread.Sleep(2000);

            //################################# Order Fulfillment #############################################

            //Enter Order
            customerRelationshipHelper.SendText("Order", "30");
            Thread.Sleep(2000);

            //Enter ZeroPercentage
            customerRelationshipHelper.SendText("ZeroPercentage", "30");
            Thread.Sleep(2000);

            //Enter OnePercentage
            customerRelationshipHelper.SendText("OnePercentage", "30");
            Thread.Sleep(2000);

            //Enter EightPercentage
            customerRelationshipHelper.SendText("EightPercentage", "30");
            Thread.Sleep(2000);

            //Enter FifteenPercentage
            customerRelationshipHelper.SendText("FifteenPercentage", "30");
            Thread.Sleep(2000);

            //Enter ThirtyPercentage
            customerRelationshipHelper.SendText("ThirtyPercentage", "30");
            Thread.Sleep(2000);

            //Select DipositedDropdown value
            customerRelationshipHelper.Select("DipositedDropdown", "Date of Delivery");
            Thread.Sleep(2000);

            // Enter DateTimeExplane 
            customerRelationshipHelper.SendText("DateTimeExplane", "30");
            Thread.Sleep(2000);

            //Enter PurchasePercentage
            customerRelationshipHelper.SendText("PurchasePercentage", "30");
            Thread.Sleep(2000);

            // Select FulFillDropdown value
            customerRelationshipHelper.Select("FulFillDropdown", "Direct");
            Thread.Sleep(2000);

            //Select RenewalsDropdown value
            customerRelationshipHelper.Select("RenewalsDropdown", "Yes");
            Thread.Sleep(2000);

            //################################# Fulfillment House #############################################

            //Click FulFillExpend
            customerRelationshipHelper.ClickOnButton("FulFillExpend");
            Thread.Sleep(2000);

            //Enter FulFillName	
            customerRelationshipHelper.SendText("FulFillName", "Test Name");
            Thread.Sleep(2000);

            //Enter FulFillDeliveryTime
            customerRelationshipHelper.SendText("FulFillDeliveryTime", "30");
            Thread.Sleep(2000);
            /*
                        //Enter FulfillAddress
            <<<<<<< HEAD
                   //     customerRelationshipHelper.SendText("FulfillAddress", "Test Address");
                    //    Thread.Sleep(2000);
            =======
                        customerRelationshipHelper.SendText("FulFillAddress", "Test Address");
                        Thread.Sleep(2000);
            >>>>>>> dc733d932fb49ab56af5305656313b54ed2cfe5e   */

            //Enter FulFillCity
            customerRelationshipHelper.SendText("FulFillCity", "Test City");
            Thread.Sleep(2000);

            //Select FulFillStateDropdown
            customerRelationshipHelper.Select("FulFillStateDropdown", "CT");
            Thread.Sleep(2000);

            //Enter FulFillZip
            customerRelationshipHelper.SendText("FulFillZip", "2010302");
            Thread.Sleep(2000);

            //Enter FulFillPhone
            customerRelationshipHelper.SendText("FulFillPhone", "1234567890");
            Thread.Sleep(2000);

            //Enter FulFillDecription
            customerRelationshipHelper.SendText("FulFillDecription", "Test Description");
            Thread.Sleep(2000);

            //################################# Shipping Service-#################################

            //Click on ShippingExpend
            customerRelationshipHelper.ClickOnButton("ShippingExpend");
            Thread.Sleep(2000);

            //Enter ShippingName
            customerRelationshipHelper.SendText("ShippingName", "Test Name");
            Thread.Sleep(2000);

            //Enter ShippingDeliveryTime
            customerRelationshipHelper.SendText("ShippingDeliveryTime", "30");
            Thread.Sleep(2000);

            //Enter ShippingAddress
            customerRelationshipHelper.SendText("ShippingAddress", "Test Address");
            Thread.Sleep(2000);

            //Enter ShippingCity
            customerRelationshipHelper.SendText("ShippingCity", "Test City");
            Thread.Sleep(2000);

            //Select ShippingStateDropdown
            customerRelationshipHelper.Select("ShippingStateDropdown", "AK");
            Thread.Sleep(2000);

            //Enter ShippingZip
            customerRelationshipHelper.SendText("ShippingZip", "201301");
            Thread.Sleep(2000);

            //################################# Incentives #################################

            //Click on IncentivesExpend
            customerRelationshipHelper.ClickOnButton("IncentivesExpend");
            Thread.Sleep(2000);


            //Select IncentivesOfferedDropdown
            customerRelationshipHelper.Select("IncentivesOfferedDropdown", "Yes");
            Thread.Sleep(2000);

            //Enter IncentivesOfferedText
            customerRelationshipHelper.SendText("IncentivesOfferedText", "30");
            Thread.Sleep(2000);

            //################################# Sales Deposit-#################################

            //Click on SalesExpend
            customerRelationshipHelper.ClickOnButton("SalesExpend");
            Thread.Sleep(2000);

            //Select SalesDepositDropdown
            customerRelationshipHelper.Select("SalesDepositDropdown", "Yes");
            Thread.Sleep(2000);

            //Enter SalesTransation
            customerRelationshipHelper.SendText("SalesTransation", "30");
            Thread.Sleep(2000);

            //Enter SalesPercentage
            customerRelationshipHelper.SendText("SalesPercentage", "30");
            Thread.Sleep(2000);

            //Select SalesShippedDropdown
            customerRelationshipHelper.Select("SalesShippedDropdown", "Yes");
            Thread.Sleep(2000);

            //Select SalesDaysDropdown
            customerRelationshipHelper.Select("SalesDaysDropdown", "31-60");
            Thread.Sleep(2000);

            //################################# Refund Policy-#################################

            //Click RefundExpend
            customerRelationshipHelper.ClickOnButton("RefundExpend");
            Thread.Sleep(2000);

            //Select RefundSalesDropdown
            customerRelationshipHelper.Select("RefundSalesDropdown", "Yes");
            Thread.Sleep(2000);

            //Select RefundPolicyDropdown
            customerRelationshipHelper.Select("RefundPolicyDropdown", "Cash");
            Thread.Sleep(2000);

            //Select RefundTransactionsDropdown
            customerRelationshipHelper.Select("RefundTransactionsDropdown", "None");
            Thread.Sleep(2000);

            //Select RefundDaysDropdown
            customerRelationshipHelper.Select("RefundDaysDropdown", "4-7");
            Thread.Sleep(2000);

//###########################   TERMINALS AND EQUIPMENTS

            //Click on Terminal And Equipment Tab
            terminalsAndEquipment.ClickElement("ClickTerminalAndEquipmentTab");

            //######################## Select Equipment  ###############################################

            //Select Processor
            terminalsAndEquipment.Select("Processor", "604");

            //Select Processor
            terminalsAndEquipment.Select("TypeTAE", "Check Reader");

            //Click on Add Equipment Btn
            terminalsAndEquipment.ClickElement("AddEquipmentBtn");

            //Enter Equip name
            terminalsAndEquipment.TypeText("EnterEquipNmae", "MAGTEK MINI-MICR");

            //Click on Equip Search 
            terminalsAndEquipment.ClickElement("ClickEquipSeach");

            //Click Click Equipment
            terminalsAndEquipment.ClickElement("ClickEquipment");

            //Click on MAGTAK MINI 
            terminalsAndEquipment.ClickElement("ClickMGTAKMINI");

            //#####################################   CHECK READER   ########################################################

            /*      //Select Version
            terminalsAndEquipment.Select("Version", "Check Reader");

            //Select Processor
            terminalsAndEquipment.Select("TypeTAE", "Check Reader");

            //Select Processor
            terminalsAndEquipment.Select("TypeTAE", "Check Reader");

            //Select Processor
            terminalsAndEquipment.Select("TypeTAE", "Check Reader");      */


            //###########################################  Equipment Option  #####################################

            //Click on Equipment Option 
            terminalsAndEquipment.ClickElement("ClickOnExpandBtnEquipmentOptn");

            //Select Merchant Trannied By
            terminalsAndEquipment.Select("MerchantTranniedBy", "Agent");

            //Select TXP Integration
            terminalsAndEquipment.Select("TXPIntegration", "Processor");

            //Select Third Party Processor Used
            terminalsAndEquipment.Select("ThirdPartyProcessorUsed", "None");

            //Enter If Other
            terminalsAndEquipment.TypeText("IfOther", "Test");

            //Enter WireLessNetwork
            terminalsAndEquipment.TypeText("WireLessNetwork", "wire Less Test");

            //Select Version
            //terminalsAndEquipment.Select("Version", "Check Reader");

            //Click  Click Last Four Digit
            terminalsAndEquipment.ClickElement("ClickLastFourDigit");

            //Click  PBXCode
            terminalsAndEquipment.ClickElement("PBXCode");

            //Click Cash back
            terminalsAndEquipment.ClickElement("CashBack");

            //Click  Click Servers
            terminalsAndEquipment.ClickElement("Servers");

            //Click BarTab
            terminalsAndEquipment.ClickElement("BarTab");

            //Click FastWay
            terminalsAndEquipment.ClickElement("FastWay");

            //Click  Both Recipient Signature Line
            terminalsAndEquipment.ClickElement("BothRecipientSignatureLine");

            //Click  BothRecipientNoSignatureLine
            terminalsAndEquipment.ClickElement("BothRecipientNoSignatureLine");


            //Click  All
            terminalsAndEquipment.ClickElement("All");

            //Click Void
            terminalsAndEquipment.ClickElement("Void");

            //Enter Other
            terminalsAndEquipment.TypeText("Other", "Testing");

            //Enter Debit Cash back Max Amount 
            terminalsAndEquipment.TypeText("DebitCashbackMaxAmount", "Tester");

            //Enter Other
            terminalsAndEquipment.Select("PaymentForEquipmentwilbe", "Lease");

            //Enter Other
            terminalsAndEquipment.TypeText("SpecialInstruction", "Testing");


            //###########################################  Equipment Option  #####################################

            //Click on Equipment Features Tab
            terminalsAndEquipment.ClickElement("ClickOnEquipmentFeaturesTab");

            //Select Merchant Trannied By
            terminalsAndEquipment.Select("SelectPinBasedDebit", "Yes");

            //Select SelectAmex
            terminalsAndEquipment.Select("SelectAmex", "Yes");

            //Select EBTServices
            terminalsAndEquipment.Select("EBTServices", "cash");

            //Enter EnterEBTNFS
            terminalsAndEquipment.TypeText("EnterEBTNFS", "Test");

            //Enter MultiMerchant
            terminalsAndEquipment.Select("MultiMerchant", "Yes");

            //Select  ParentMid
            terminalsAndEquipment.TypeText("ParentMid", "TEST");


            //Select SelectAVS
            terminalsAndEquipment.Select("SelectAVS", "Yes");

            //Select corpPruch
            terminalsAndEquipment.Select("corpPruch", "Yes");

            //Select VerificationCode
            terminalsAndEquipment.Select("VerificationCode", "Yes");

            //Select PartialAuth
            terminalsAndEquipment.Select("PartialAuth", "Yes");

            //SelectAutoClose
            terminalsAndEquipment.Select("SelectAutoClose", "Yes");


            //Select Invoice
            terminalsAndEquipment.Select("SelectInvoice", "Yes");

            //Select ConnectionMethod
            terminalsAndEquipment.Select("ConnectionMethod", "wireless");

            //Select StoreMethod
            terminalsAndEquipment.Select("StoreMethod", "Yes");

            //Select DialPreFix
            terminalsAndEquipment.TypeText("DialPreFix", "Test");

            //Select MemorySize
            terminalsAndEquipment.Select("MemorySize", "1Meg");

            //Select AutoCloseTime
            terminalsAndEquipment.Select("EMVCapabilities", "contactless");

            //Select Tips Of Time Sale
            terminalsAndEquipment.Select("TipsOfTimeSale", "Yes");

            //Select TipCalculator
            terminalsAndEquipment.Select("TipCalculator", "Yes");


            //################################ TERMINAL Variable   ######################################

            //Click on Equipment Features Tab
            terminalsAndEquipment.ClickElement("TerminalVariable");

            //Select ProviderCode
            terminalsAndEquipment.Select("SelectProviderCode", "SOF");

            //Select ApplicationCode
            terminalsAndEquipment.Select("SelectApplicationCode", "Restaurant");

            //###################################### STORE VARIABLE  ###############################################

            // Click Expend Btn Store Variable
            terminalsAndEquipment.ClickElement("ClickExpendBtnStoreVariable");

            //Select CallWatingTerminalLine
            terminalsAndEquipment.Select("CallWatingTerminalLine", "Yes");

            //Enter NumberDailedForOutSideLine
            terminalsAndEquipment.TypeText("NumberDailedForOutSideLine", "10");

            //Select RollOverLines
            terminalsAndEquipment.Select("RollOverLines", "Yes");

            //Select ToneOrRotary
            terminalsAndEquipment.Select("ToneOrRotary", "Tone");

            //Select Processor To Train Merchant
            terminalsAndEquipment.Select("ProcessorToTrainMerchant", "Yes");

            //Select Processor To Terminal
            terminalsAndEquipment.Select("ProcessorTotErminal", "Yes");

//#########################    OWNERS

            //Click on Terminal And Equipment Tab
            ownersHelper.ClickElement("ClickOwnerTab");

            //######################## OWNER IFORMATION 1  ###############################################

            //Select First Name Salutation
            ownersHelper.Select("FirstNameSalutation", "Mr");

            //Enter FirstName
            ownersHelper.TypeText("FirstName", "Test");

            //Enter Lastname
            ownersHelper.TypeText("LastName", "Tester");

            //Enter TitleOwner
            ownersHelper.TypeText("TitleOwner", "Tester Testing");


            //Enter DateOfDirt
            ownersHelper.TypeText("DateOfDirt", "1991-11-06");


            //Enter Language
            ownersHelper.Select("Language", "English");


            //Enter OwnerShip Percentage
            ownersHelper.TypeText("OwnerShipPercentage", "55");

            //##########################################  Owners Identification Information  ######################

            //Enter Type
            ownersHelper.Select("Type", "State ID");


            //Enter IDOwner
            ownersHelper.TypeText("IDOwner", "ID2001");

            //Enter State   (STATE DROPDOWN DISPLAYED AS BLANK)
            ownersHelper.Select("State", "AL");

            //Enter DateOfIssue
            ownersHelper.TypeText("DateOfIssue", "2015-03-01");

            //Enter Date Of Expire
            ownersHelper.TypeText("DateOfExpire", "2015-05-01");


            //########################## Owners Bankruptcy Information  ###########################################

            //Select OwnerFieldBankrupty
            ownersHelper.Select("OwnerFieldBankrupty", "Yes");

            //Select ChapterField
            ownersHelper.Select("ChapterField", "11");

            //Select StateField
            ownersHelper.Select("StateField", "AL");

            //Enter DateField
            ownersHelper.TypeText("DateField", "2015-05-01");

            //Enter DateEmerged
            ownersHelper.TypeText("DateEmerged", "2015-07-01");


            //################################Previous Business Deatils  ############################################
            //Enter IfYesEnterName
            ownersHelper.TypeText("IfYesEnterName", "No");

            //#######################    Business Identification Information   #########################3

            //Select BusinessIdentificationInfoType
            ownersHelper.Select("BusinessIdentificationInfoType", "Tax Return");

            //Select BusinessIdentificationInfoID
            ownersHelper.TypeText("BusinessIdentificationInfoID", "11");

            //Enter BIInfoPlaceofIssue
            ownersHelper.TypeText("BIInfoPlaceofIssue", "AL");

            //Enter DateOfIssance
            ownersHelper.TypeText("DateOfIssance", "2015-05-01");

            //Enter BIiNFOExpiratoionDate
            ownersHelper.TypeText("BIiNFOExpiratoionDate", "2015-07-01");

            //########################     Business Bankruptcy Information  ############################################3

            //Select FieldForBanKrupty
            ownersHelper.Select("FieldForBanKrupty", "Yes");

            //Select ChapterField
            ownersHelper.Select("ChapterField", "11");

            //Enter StateField
            ownersHelper.Select("StateField", "AL");

            //Enter DateOfIssance
            ownersHelper.TypeText("DateOfIssance", "2015-05-01");

            //Enter BIiNFOExpiratoionDate
            ownersHelper.TypeText("BIiNFOExpiratoionDate", "2015-07-01");

            //################################# Contact Add Phone Number ###################################

            //Select ClickOnAddphone
            ownersHelper.ClickElement("ClickOnAddphone");

            //EnterPhoneNumber
            ownersHelper.TypeText("EnterPhoneNumber", "1453543528");

            //Enter StateField
            ownersHelper.TypeText("EnterEntension", "121");

            //Enter DateOfIssance
            ownersHelper.ClickElement("Primary");

            //################################## Add Email   ######################################

            // Clik On Add Email Btn
            ownersHelper.ClickElement("ClikOnAddEmailBtn");

            //Enter EnterEmail
            ownersHelper.TypeText("EnterEmail", "1453543528");

            //Select Primary
            ownersHelper.ClickElement("Primary");

            //Select OptedOut
            ownersHelper.ClickElement("OptedOut");

            //############################## Add Address   #########################

            // Click Add Address Link
            ownersHelper.ClickElement("ClickAddAddressLink");

            //Select Address Type
            ownersHelper.Select("AdreesType", "Corporate");

            //Enter AddressLine1
            ownersHelper.TypeText("AddressLine1", "89 TEST");

            //Enter AddressLine2
            ownersHelper.TypeText("AddressLine2", "TEST CITY");

            //Select State
            ownersHelper.Select("SelectState", "AK");

            //Enter Zip
            ownersHelper.TypeText("Zip", "201005");
























            //Click on Save BUtton
            clientHelper.ClickElement("AddClients/ClickOnSaveBtn");
            clientHelper.WaitForWorkAround(18000);
        }
    }
}
