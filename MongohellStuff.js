// JavaScript source code
for (i = 0; i < 1000; i++) {
    db.dummies.insert({
        Name: "dummy nr." + i,
        theDate: new Date().getDate()
    });
}