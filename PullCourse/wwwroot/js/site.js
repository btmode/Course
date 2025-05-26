// Обновление времени
function updateTime() {
    const now = new Date();
    document.getElementById('current-time').textContent = now.toLocaleTimeString('ru-RU', {
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
    });
}

// Функция для "моргания" ячейки
function flashCell(cell, isUp) {
    // Сначала удаляем предыдущие классы
    cell.classList.remove('flash-up', 'flash-down');

    // Принудительно вызываем перерасчет стилей
    void cell.offsetWidth;

    // Добавляем соответствующий класс
    cell.classList.add(isUp ? 'flash-up' : 'flash-down');

    // Удаляем класс после анимации
    setTimeout(() => {
        cell.classList.remove('flash-up', 'flash-down');
    }, 1000);
}

// Обновление таблицы
function updateTable(data) {
    const row = document.querySelector(`tr[data-code="${data.CurrencyCode}"]`);

    if (row) {
        const buyCell = row.querySelector('.buy-rate');
        const sellCell = row.querySelector('.sell-rate');

        // Сравниваем старые и новые значения
        const oldBuy = parseFloat(buyCell.textContent);
        const newBuy = parseFloat(data.Buy);
        const oldSell = parseFloat(sellCell.textContent);
        const newSell = parseFloat(data.Sell);

        // Обновляем значения
        buyCell.textContent = newBuy.toFixed(2);
        sellCell.textContent = newSell.toFixed(2);

        // Анимируем изменения
        if (newBuy > oldBuy) flashCell(buyCell, true);
        else if (newBuy < oldBuy) flashCell(buyCell, false);

        if (newSell > oldSell) flashCell(sellCell, true);
        else if (newSell < oldSell) flashCell(sellCell, false);
    } else {
        const tbody = document.querySelector('tbody');
        const newRow = document.createElement('tr');
        newRow.setAttribute('data-code', data.CurrencyCode);
        newRow.innerHTML = `
            <td>${data.CurrencyCode}</td>
            <td class="buy-rate">${parseFloat(data.Buy).toFixed(2)}</td>
            <td class="sell-rate">${parseFloat(data.Sell).toFixed(2)}</td>
        `;
        tbody.appendChild(newRow);
    }
}

// Инициализация SignalR
function initSignalR(currentCity) {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/currencyHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ReceiveUpdate", function(message) {
        try {
            const data = JSON.parse(message);
            if (data.City === currentCity) {
                updateTable(data);
            }
        } catch (e) {
            console.error("Error processing update:", e);
        }
    });

    connection.start()
        .then(() => connection.invoke("JoinCityGroup", currentCity))
        .catch(err => console.error("Connection error:", err));
}

// Инициализация при загрузке
document.addEventListener('DOMContentLoaded', function() {
    setInterval(updateTime, 1000);
    updateTime();

    const currentCity = document.body.getAttribute('data-current-city');
    initSignalR(currentCity);
});