var  Cuntry ={
	
	GetCountry: function () {
	    var xmlhttp = new XMLHttpRequest();
	    xmlhttp.open("GET", "http://northwind.servicestack.net/customers.json", true);
	    xmlhttp.send();
		try
		{
			xmlhttp.onreadystatechange = function() {
    			if (this.readyState == 4 && this.status == 200) {
        			var myObj = JSON.parse(this.responseText);
        			Cuntry.AppendContent(myObj);
    			}
			}
		}
		catch(err)
		{
			console.log( err.message);
		}
	},

	AppendContent : function ( myObj)
	{
		try 
		{
	    	document.getElementById('divMainEntry').innerHTML = "";
		    HTMLBilder.BuildMainEntry("three", "3", "1");
		    Cuntry.GetCountrys(myObj); 
		}
		catch(err)
	    {
    		console.log( err.message);
		}	
	},
	
	GetCountrys:function(myObj){
		
		let className = 'country', childClassName ='cities';
 		let country=[], cities={};
		let checkcountries = new Array();
		try
		{
			for(y =0; y < myObj.Customers.length; y++)	
			{
			    if(checkcountries.includes(myObj.Customers[y].Country) == false)
			    {
			    	country = myObj.Customers[y].Country;
					cities = myObj.Customers[y].City;
					checkcountries.push(country);
					let parentId =  HTMLBilder.CreateDivElement("three",y, className);
					let imagParent=HTMLBilder.CreateDivElement(parentId ,y, className+"img");
					Cuntry.GetCountryFlag(country, imagParent);
					HTMLBilder.CreateH4Element(country, y,className, parentId);
					HTMLBilder.CreateUlElement(className, y, childClassName, cities);
			   	    Cuntry.GetCity(myObj,country,cities);
			    }
			}
		}
		catch(err)
		{
			console.log( err.message);
		}
	},
	
	GetCity : function(myObj,country,cities){
		
		try
		{
			for(i = 0; i < myObj.Customers.length; i++)	
	    	{
				if (myObj.Customers[i].Country === country && myObj.Customers[i].City != cities)
				{
			   		cities = myObj.Customers[i].City;
	           		HTMLBilder.CreateLiElement(cities, i, y, "cities");
				}
			}
		}
		catch(err)
		{
			console.log( err.message);
		}
	},
	AttachFlagToCountry : function(myObj, parentId)
	{
		try
		{
			window.imgId =0;
			let idFromWindow = window.imgId;
			let id = HTMLBilder.CreatrImageElement(parentId,"country_flag",idFromWindow, myObj);
            window.imgId++;

		}
		catch(err)
		{
			console.log(err.message);
		}
	},
	
	GetCountryFlag: function (countryName, parentId) {
	    
	    let xmlhttp = new XMLHttpRequest();
	    let imageNameArray =['germany', 'uk', 'mexico'];
		try
		{
		
			if(imageNameArray.includes(countryName.toLowerCase()) == true){
			    xmlhttp.open("GET", countryName.toLowerCase()+".txt", true);
	   		    xmlhttp.send();
				xmlhttp.onreadystatechange = function() {
	    			if (this.readyState == 4 && this.status == 200) {
	        			var myObj = this.responseText;
	        			Cuntry.AttachFlagToCountry(myObj, parentId);
	    			}
				}
			}
		}
		catch(err)
		{
			console.log( err.message);
		}
	}

};



