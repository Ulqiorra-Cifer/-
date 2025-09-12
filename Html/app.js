document.getElementById('convertBtn').addEventListener('click', convertCurrency);

async function convertCurrency() {
    const amount = document.getElementById('amount').value;
    const fromCurrency = document.getElementById('fromCurrency').value;
    const toCurrency = document.getElementById('toCurrency').value;
    if (isNaN(amount) || amount <= 0) {
        alert('Пожалуйста, введите корректную сумму!');
        return;
    }
    const url = `https://v6.exchangeratesapi.io/latest?base=${fromCurrency}`; 
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Ошибка при получении данных');
        }
        const data = await response.json();
        const rate = data.rates[toCurrency];
        const convertedAmount = (amount * rate).toFixed(2);
        document.getElementById('result').textContent = `${amount} ${fromCurrency} = ${convertedAmount} ${toCurrency}`;
    } catch (error) {
        console.error('Ошибка:', error);
        alert('Не удалось получить данные о курсах валют. Попробуйте позже.');
    }
}
