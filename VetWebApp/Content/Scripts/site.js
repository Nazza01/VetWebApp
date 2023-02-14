// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Increases font size for each element with the class name "font-access"
function incSize(e) {
	var elements = document.getElementsByClassName("font-access");
	for (var i = 0; i < elements.length; i++)
	{
		console.log("Increasing font size for: " + elements[i].style.fontFamily);
		elements[i].style.fontSize = 'xx-large';
	}
}

function resetSize(e) {
	var elements = document.getElementsByClassName("font-access");

	for (var i = 0; i < elements.length; i++)
	{
		console.log("Resetting font size for: " + elements[i].style.fontFamily);
		elements[i].style.fontSize = 'large';
	}
}

function decSize(e) {
	var elements = document.getElementsByClassName("font-access");

	for (var i = 0; i < elements.length; i++)
	{
		console.log("Changing font size for: " + elements[i].style.fontFamily);
		elements[i].style.fontSize = 'small';
	}
}

// Font Styling

function fontType(event) {
	var fontfam = event.value;
	var elements = document.getElementsByClassName("font-access");

	for (var i = 0; i < elements.length; i++) {
		console.log("Changing font type for: " + elements[i].style.fontFamily);
		elements[i].style.fontFamily = fontfam;
	}
}

