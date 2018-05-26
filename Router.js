var glob  = 0;
var arrayOfMethods = [];


function RouterExp(buttonId)
{
    arrayOfMethods = [CatImage.GetBase64, Cuntry.GetCountry, Less.LessQuestion];
	try{
		if(buttonId === 1)
		{
			let index;
			if(this.glob > (this.arrayOfMethods.length-1))
			{
			    this.arrayOfMethods[arrayOfMethods.length - arrayOfMethods.length]();
			    index = arrayOfMethods.length - arrayOfMethods.length;
			    sessionStorage.setItem('glob', index.toString());
			    glob = 1;
			}
			else if( this.glob < 0)
			{
				this.glob++;
				this.arrayOfMethods[this.glob]
				index = this.glob;
				sessionStorage.setItem('glob',index.toString());
			}
			else
			{
				this.arrayOfMethods[this.glob]();
				sessionStorage.setItem('glob', this.glob.toString());
				this.glob++;
			}
		}
		else if(buttonId === -1)
		{
			if(this.glob > (this.arrayOfMethods.length-1))
			{
			    this.glob--;
			    this.arrayOfMethods[glob]();
			    index = this.glob;
			    sessionStorage.setItem('glob',index.toString());
			}
			else if(this.glob < 0)
			{
				this.arrayOfMethods[arrayOfMethods.length-1]();
				index = this.arrayOfMethods.length - 1;
				sessionStorage.setItem('glob', index.toString());
				this.glob = 1;
			}
			else
			{
    			this.arrayOfMethods[glob]();
    			sessionStorage.setItem('glob', this.glob.toString());
    			this.glob--;
			}
		}
	}catch(err){
		console.log(err);
	}
};

window.onbeforeunload = function() {
   
};

onload = function () {
	
	let arrayOf = [CatImage.GetBase64, Cuntry.GetCountry, Less.LessQuestion];
	try{
		arrayOf[parseInt(sessionStorage.getItem('glob'))]();
	}catch(err)
	{
		console.log();
	}
	
};