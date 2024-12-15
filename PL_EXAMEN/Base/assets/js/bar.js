new Chart(document.getElementById("barchart"), {
	type: 'bar',
	data: {
		labels: ['Gerente', 'Ejecutivo', 'Regular'],
		datasets: [{
			data: [10,20,30],
			label: 'San Jose',
			backgroundColor: "#4755AB",
			borderWidth: 1,
		}, {
			data: [30,10,70],
			label: 'Alajuela',
			backgroundColor: "#E7EDF6",
			borderWidth: 1,
		}, {
				data: [1, 2, 3],
				label: 'Cartago',
				backgroundColor: "#EF3F6",
				borderWidth: 1,
		}
			, {
				data: [31, 22, 31],
				label: 'Liberia',
				backgroundColor: "#EF3F6",
				borderWidth: 1,
			}
			, {
				data: [10, 12, 33],
				label: 'Guanacaste',
				backgroundColor: "#EF3F6",
				borderWidth: 1,
			}
		]
	},
	options: {
		responsive: true,
		legend: {
			position: 'top',
		},
	}
});
