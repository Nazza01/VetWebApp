// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setImage(index)
{
	var bgimg = document.body.style;
	if (index == "dog")
	{
		bgimg.backgroundImage = "url('/Content/backgrounds/dog.jpg')";
		bgimg.backgroundImage.opacity = 0.2;
	}
	else if (index == "cat")
	{
		bgimg.backgroundImage = "url('/Content/backgrounds/cat.jpg')";
	}
	else if (index == "both")
	{
		bgimg.backgroundImage = "url('/Content/backgrounds/both.jpg')";
	}
}

function resetImage() {
	console.log("Resetting background color");
	document.body.style
	document.body.style.backgroundColor = "white";
}

