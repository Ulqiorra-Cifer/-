//N1
for (let i = 1; i <= 100; i++) {
    console.log(i);
  }

//N2
function isEven(num) {
    return num % 2 === 0;
  }
  
  console.log(isEven(4));
  console.log(isEven(7));  
//N3
function reverseString(s) {
    return s.split('').reverse().join('');
  }
  
  console.log(reverseString("hello"));
//N4
function maxOfThree(a, b, c) {
    return Math.max(a, b, c);
  }

  console.log(maxOfThree(3, 7, 5));
//N5
function isPalindrome(s) {
    let cleanedStr = s.replace(/[^a-zA-Z0-9]/g, '').toLowerCase();
    return cleanedStr === cleanedStr.split('').reverse().join('');
  }
  
  console.log(isPalindrome("A man a plan a canal Panama"));
  console.log(isPalindrome("hello")); 
//N6
function countVowels(s) {
    const vowels = "aeiouAEIOU";
    let count = 0;
    for (let i = 0; i < s.length; i++) {
      if (vowels.includes(s[i])) {
        count++;
      }
    }
    return count;
  }
  
  console.log(countVowels("hello world")); 
//N7
function sumOfArray(arr) {
    return arr.reduce((acc, num) => acc + num, 0);
  }
  
  console.log(sumOfArray([1, 2, 3, 4, 5])); 
//N8
function searchElement(arr, element) {
    return arr.includes(element);
  }
  
  console.log(searchElement([1, 2, 3, 4, 5], 3)); 
  console.log(searchElement([1, 2, 3, 4, 5], 6));  
//N9
function filterArray(arr, condition) {
    return arr.filter(condition);
  }
  
  console.log(filterArray([1, 2, 3, 4, 5, 6], num => num % 2 === 0));
//N10
function removeDuplicates(arr) {
    return [...new Set(arr)];
  }
  
  console.log(removeDuplicates([1, 2, 3, 3, 4, 5, 5]));
  
  
  
  
  
  