"use strict";
// 1. Variable Declaration (explicit types)
const userName = "John";
let age = 25;
const email = "john@example.com";
const isSubscribed = true;
// 2. Type Inference (no explicit types)
let city = "Bangalore";
let loginCount = 5;
// 4. Template Literal
let userProfile = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
// Increment age
age = age + 1;
// Check eligibility for premium plan
let isEligibleForPremium = age > 18 && isSubscribed;
// Additional comparisons 
let isAdult = age >= 18;
let isMinor = age < 18;
console.log("User Name:", userName);
console.log("Age after increment:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);
console.log("City (inferred):", city);
console.log("Login Count (inferred):", loginCount);
console.log("User Profile:", userProfile);
console.log("Is Adult:", isAdult);
console.log("Is Minor:", isMinor);
console.log("Eligible for Premium:", isEligibleForPremium);
