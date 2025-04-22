# Directory structure

To be considered:

* `ckeditor/` : contains CKEditor 4 (v4.5.11), which is used for the integration examples.
* `images/` : contains some icons, used for the new buttons to be added.
* `main.js` : contains the integration of INVOX Medical into CKEditor.
* `textwriter.js` : implementation of the CKEditor 4 writer.




# Remarks

In the `ckeditor/config.js` file you have to set the toolbar group name:
  

```javascript
config.toolbarGroups = [
    { name: 'invox-toolbar' },
    ...
];
```

> This allow you to find toolbar name and add new buttons into the editor.
