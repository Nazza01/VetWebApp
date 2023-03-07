// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function load() {
	setImage(localStorage.getItem('img'));
	document.body.style.backgroundRepeat = "no-repeat";
	document.body.style.backgroundSize = "cover";
}

function setImage(index)
{
	var bgimg = document.body.style;

	if (index == "dog") {
		bgimg.backgroundImage = "url('/Content/backgrounds/dog.jpg')";
		localStorage.setItem("img", "dog");
	}
	else if (index == "cat") {
		bgimg.backgroundImage = "url('/Content/backgrounds/cat.jpg')";
		localStorage.setItem("img", "cat");
	}
	else if (index == "both") {
		bgimg.backgroundImage = "url('/Content/backgrounds/both.jpg')";
		localStorage.setItem("img", "both");
	}
	console.log("Changing background to: " + localStorage.getItem("img"));
}

function resetImage() {
	console.log("Resetting background color");
	document.body.style.backgroundImage = "url('')";
	localStorage.setItem("img", "none");
}

window.onload = load();
