'use strict'
var Less = {
	
	AppendLessContent : function (myObj) {
		
		let className = "less", id = 1;
		try{
			document.getElementById('divMainEntry').innerHTML = "";
			HTMLBilder.BuildMainEntry("three", "0", "2");
			HTMLBilder.CreateH4Element("dynamic stylesheet language", id,className , "three");
			HTMLBilder.CreateParaElement("three",className, id, "The dynamic stylesheet language LESS extends CSS with dynamic behavior such as variables, mixins, operations and functions. LESS runs on both the client-side (IE 6+, Webkit, Firefox) and server-side, with Node.js.In simple terms, LESS allows you to write CSS in a smarter way by combining functions, mixins, operations and more. This means you write more concise style information and can reuse things like colors and styles more easily. The Pro edition of the Web Workbench supports generating CSS files automatically rather than needing to do JavaScript parsing. Thankfully the Web Workbench includes all the requirements and is a nice simple one install way of working with LESS");
	    	HTMLBilder.CreatrImageElement("three",className,id, myObj);
		}catch(err){
			console.log(err);
		}
	},	
	  
	LessQuestion : function () {
	    
	    var xmlhttp = new XMLHttpRequest();
	    xmlhttp.open("GET", "lessQuestion.txt", true);
	    xmlhttp.send();
	    try{
	    	xmlhttp.onreadystatechange = function() {
	    		if (this.readyState == 4 && this.status == 200) {
	        		var myObj = this.responseText;
	        		Less.AppendLessContent(myObj);
	    		}
			}
		}catch(err){
			console.log(err);
		}
	}
}