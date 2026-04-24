// 1. Variable Declaration (explicit types)
const userName: string = "John";
let age: number = 25;
const email: string = "john@example.com";
const isSubscribed: boolean = true;

// 2. Type Inference (no explicit types)
let city = "Bangalore";
let loginCount = 5;

// 4. Template Literal
let userProfile: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;


// Increment age
age = age + 1;

// Check eligibility for premium plan
let isEligibleForPremium: boolean = age > 18 && isSubscribed;

// Additional comparisons 
let isAdult: boolean = age >= 18;
let isMinor: boolean = age < 18;


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