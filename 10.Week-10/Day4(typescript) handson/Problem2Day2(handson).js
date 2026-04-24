"use strict";
function getWelcomeMessage(name) {
    return `welcome to the page.${name}`;
}
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `Hello ${name}, you are ${age} years old`;
    }
    else {
        return `Hello ${name}`;
    }
}
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed
        ? `Hello ${name}, you are subscribed`
        : `Hello ${name}, you are not subscribed`;
}
// 4. Boolean Return Type
function isEligibleForPremium1(age, isSubscribed) {
    return age > 18 && isSubscribed;
}
// 5. Arrow Function (rewrite)
const getWelcomeMessageArrow = (name) => {
    return `Welcome ${name}!`;
};
// Arrow boolean function
const isAdult1 = (age) => age >= 18;
// 6. Lexical `this`
const notificationService = {
    appName: "MyApp",
    //  lexical `this` with arrow function
    sendNotification: (userName) => {
        return `Hello ${userName}, welcome to ${notificationService.appName}`;
    }
};
// Better comparison (normal function with real `this`)
const notificationServiceProper = {
    appName: "MyApp",
    sendNotification(userName) {
        return `Hello ${userName}, welcome to ${this.appName}`;
    }
};
console.log(getWelcomeMessage("John"));
console.log(getUserInfo("Alice", 25));
console.log(getUserInfo("Bob"));
console.log(getSubscriptionStatus("David", true));
console.log(getSubscriptionStatus("Emma"));
console.log("Eligible:", isEligibleForPremium1(20, true));
console.log("Eligible:", isEligibleForPremium1(16, true));
console.log(getWelcomeMessageArrow("Chris"));
console.log("Is Adult:", isAdult1(22));
console.log(notificationService.sendNotification("John"));
console.log(notificationServiceProper.sendNotification("Alice"));
