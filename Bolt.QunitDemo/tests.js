
module("Basic Unit Tests");

test("Sample test", function () {
    expect(1);
    equals(2, 2, 'Expected 2 as the result');
});

test("Sample failing test", function() {
    expect(2);
    equals(2, 1, 'Expected 2 as the result');
    equals(1, 2, 'Expected 1 as the result');
});

test("Second passing Test", function () {
    expect(2);
    equals(2, 2, 'Expected 2 = 2 as the result');
    equals(3, 3, 'Expected 3 = 3 as the result');
});

test("Second failing test", function () {
    expect(2);
    equals(0, 1, 'Expected 0 as the result');
    equals(1, 1, 'Expected 1 as the result');
});