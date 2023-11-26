
let jokeBox=document.getElementById('jokeBox')

const settings = {
	async: true,
	crossDomain: true,
	url: 'https://dad-jokes.p.rapidapi.com/random/joke',
	method: 'GET',
	headers: {
		'X-RapidAPI-Key': '8a53a4a4d0msh5f2606d40df4ac5p1dc159jsneaac9f9beefa',
		'X-RapidAPI-Host': 'dad-jokes.p.rapidapi.com'
	}
};

$.ajax(settings).done(function (response) {
	console.log(response);

	var setup = response.body[0].setup
	var punchline = response.body[0].punchline

	jokeBox.innerHTML = `<h2 class="jokeSetup">${setup}</h2><br><h3 class="jokePunchline">${punchline}</h3>`	
});