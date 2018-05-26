var CatImage = {
	
	AppendCatContent : function(myObj) {
		let parentId, className = 'cat';
		try{
			document.getElementById('divMainEntry').innerHTML = "";
	    	parentId =HTMLBilder.BuildMainEntry("three", "1", "2");
			HTMLBilder.CreateParaElement(parentId,className, 1, "This picture is a product of base64 code,Base64 is a group of similar binary-to-text encoding schemes that represent binary data in an ASCII string format by translating it into a radix-64 representation. The term Base64 originates from a specific MIME content transfer encoding.");
			HTMLBilder.CreatrImageElement("three",className,1, myObj);
		}catch(err){
			console.log(err);
		}
	},
	 
	GetBase64 : function() {
	  
	   var xmlhttp = new XMLHttpRequest();
	    xmlhttp.open("GET", "base64.txt", true);
	    xmlhttp.send();
	   try{
	   		 xmlhttp.onreadystatechange = function() {
	    		if (this.readyState == 4 && this.status == 200) {
	        		var myObj = this.responseText;
	        		CatImage.AppendCatContent(myObj);
	    		}
			}
       }catch(err){
       		console.log(err);
       }	
	}
 }

 
		
	    