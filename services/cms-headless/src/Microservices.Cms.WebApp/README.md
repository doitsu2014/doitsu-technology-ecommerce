# Introduce

## 1. Tips


### 1.1. Extract Feature Ids from UI

There is an javascript snippet to extract all supported Feature Ids on UI:

```js

var featureGroups = [...document.querySelectorAll("div.feature-group")];

var featureGroupKv = featureGroups.map(fg => {
	const headerDiv = fg.querySelector("h4").innerHTML.replace(" ", "_");
	
	return {k: headerDiv, v: [...fg.querySelectorAll("input")].map(e => e.value)};
});

var result = featureGroupKv.reduce(function(r, e) {
	r[e.k] = e.v;
	return r;
}, {});

```