package exercise5;

interface Shape {
    
    void draw();
}

class Rectangle implements Shape {
    @Override
    public void draw() {
        System.out.println("A rectangle is drawn");
    }
}

class Square implements Shape {
    @Override
    public void draw() {
        System.out.println("A Square is drawn");
    }
}

class RoundedRectangle implements Shape {
    @Override
    public void draw() {
        System.out.println("A rounded rectangle is drawn");
    }
}

class RoundedSquare implements Shape {
    @Override
    public void draw() {
        System.out.println("A rounded square is drawn");
    }
}

abstract class AbstractShapeFactory {
   
    abstract Shape getShape(String type);
}

class ShapeFactory extends AbstractShapeFactory {
    @Override
    Shape getShape(String type) {
        if ("rectangle".equals(type)) {
            return new Rectangle();
        }
        if ("square".equals(type)) {
            return new Square();
        }

        return null;
    }
}

class RoundedShapeFactory extends AbstractShapeFactory {
    @Override
    Shape getShape(String type) {
        if ("roundedRectangle".equals(type)) {
            return new RoundedRectangle();
        }
        if ("roundedSquare".equals(type)) {
            return new RoundedSquare();
        }

        return null;
    }
}

class ShapeFactoryProvider {
    private ShapeFactoryProvider() {
    }

    public static AbstractShapeFactory getShapeFactory(String type) {
        if ("normal".equals(type)) {
            return new ShapeFactory();
        }

        if ("rounded".equals(type)) {
            return new RoundedShapeFactory();
        }

        return null;
    }
}

public class Main {
    public static void main(String[] args) {
        AbstractShapeFactory roundedShapeFactory = ShapeFactoryProvider.getShapeFactory("rounded");
        AbstractShapeFactory normalShapeFactory = ShapeFactoryProvider.getShapeFactory("normal");

        // create instances
        Shape rectangle = roundedShapeFactory.getShape("roundedRectangle");
        Shape shape = normalShapeFactory.getShape("rectangle");
        Shape roundedSquare = roundedShapeFactory.getShape("roundedSquare");
        Shape square = normalShapeFactory.getShape("square");
        

        rectangle.draw();
        shape.draw();
        roundedSquare.draw();
        square.draw();
    }
}