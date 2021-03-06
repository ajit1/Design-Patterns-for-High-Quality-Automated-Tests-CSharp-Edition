﻿namespace ApiUsabilityDemos.Ninth
{
    public class CartPage : NavigatableEShopPage
    {
        private CartPage(Driver driver) 
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            Elements = new CartPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; }
        public CartPageElements Elements { get; }


        public void ApplyCoupon(string coupon)
        {
            Elements.CouponCodeTextField.TypeText(coupon);
            Elements.ApplyCouponButton.Click();
            Driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            Elements.QuantityBox.TypeText(newQuantity.ToString());
            Elements.UpdateCart.Click();
            Driver.WaitForAjax();
        }

        public void ProceedToCheckout()
        {
            Elements.ProceedToCheckout.Click();
            Driver.WaitUntilPageLoadsCompletely();
        }

        public string GetTotal()
        {
            return Elements.TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return Elements.MessageAlert.Text;
        }

        protected override void WaitForPageLoad()
        {
            Elements.CouponCodeTextField.WaitToExists();
        }
    }
}