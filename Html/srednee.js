//N2
function factorial(n){
    if(n<0) return "Error";
    let number;
    for(let i;i<=n;i++){
        number*=i;
    }
    return number;
}

console.log(factorial(5));
//N3
function isAnnagram(str1,str2){
    if(str1.lenght !== str2.lenght) return false;
    const charArr={};
    for(let char of str1.toLowerCase()){
        charArr[char]=(charArr[char] || 0)+1;  
    }
    for(let char of str2.toLowerCase()){
        if(!charArr[char]) return false;
        charArr[char]--;
    }
    return true;
}

console.log(isAnnagram("listen","silent"));
console.log(isAnnagram("bike","car"));
//N4
let arr=[1,2,3,4];
[arr[0],arr[3]]=[arr[3],arr[0]];
console.log(arr);
//N5
