var ctx = document.getElementById('myChart').getContext('2d');
var earning = document.getElementById('earning').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'polarArea',
    data: {
        labels: ['Instagram', 'Facebook', 'TikTok', 'X'],
        datasets: [{
            label: 'Seguidores/Me gusta',
            data: [5042, 10582, 3555, 2598],
            backgroundColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)'
            ],


        }]
    },
    options: {
        responsive: true,
    }
});



var myChart = new Chart(earning, {
    type: 'bar',
    data: {
        labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre',
            'Octubre', 'Noviembre', 'Diciembre'],
        datasets: [{
            label: 'Mayor numero de ventas 2023',
            data: [1234, 1954, 3097, 566, 2345, 3346, 334, 4456, 989, 7899, 4563, 7777],
            backgroundColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],

        }]
    },
    options: {
        resposive: true,
    }
});