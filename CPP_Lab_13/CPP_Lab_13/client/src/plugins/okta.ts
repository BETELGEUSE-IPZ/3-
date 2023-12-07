import { OktaAuth } from "@okta/okta-auth-js";

const oktaAuth = new OktaAuth({
  issuer: "https://dev-65684515.okta.com/oauth2/default",
  clientId: "0oadie67gmB2Vo1ax5d7",
  redirectUri: window.location.origin + "/authorization-code/callback",
  logoutUrl: window.location.origin + "/signout-callback-oidc",
  scopes: ["openid", "profile", "email", "phone"],
});

export default oktaAuth;
