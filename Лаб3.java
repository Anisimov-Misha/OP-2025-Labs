import java.util.*;

// === Prototype ===
interface Shape extends Cloneable {
    void draw();
    Shape clone();
}

class Circle implements Shape {
    private int radius;
    public Circle(int radius) {
        this.radius = radius;
    }

    @Override
    public void draw() {
        System.out.println("Drawing Circle with radius " + radius);
    }

    @Override
    public Shape clone() {
        return new Circle(this.radius);
    }
}

class Rectangle implements Shape {
    private int width, height;
    public Rectangle(int width, int height) {
        this.width = width;
        this.height = height;
    }

    @Override
    public void draw() {
        System.out.println("Drawing Rectangle with width " + width + " and height " + height);
    }

    @Override
    public Shape clone() {
        return new Rectangle(this.width, this.height);
    }
}

// === Decorator ===
abstract class ShapeDecorator implements Shape {
    protected Shape decoratedShape;

    public ShapeDecorator(Shape shape) {
        this.decoratedShape = shape;
    }

    public void draw() {
        decoratedShape.draw();
    }

    public Shape clone() {
        return decoratedShape.clone();
    }
}

class BorderDecorator extends ShapeDecorator {
    public BorderDecorator(Shape shape) {
        super(shape);
    }

    @Override
    public void draw() {
        decoratedShape.draw();
        System.out.println(" -> with border");
    }
}

class ShadowDecorator extends ShapeDecorator {
    public ShadowDecorator(Shape shape) {
        super(shape);
    }

    @Override
    public void draw() {
        decoratedShape.draw();
        System.out.println(" -> with shadow");
    }
}

// === Iterator ===
class ShapeCollection implements Iterable<Shape> {
    private List<Shape> shapes = new ArrayList<>();

    public void addShape(Shape shape) {
        shapes.add(shape);
    }

    @Override
    public Iterator<Shape> iterator() {
        return shapes.iterator();
    }
}

// === Main ===
public class DesignPatternLab {
    public static void main(String[] args) {
        Shape circle = new Circle(5);
        Shape rect = new Rectangle(3, 4);

        // Decorator
        Shape fancyCircle = new BorderDecorator(new ShadowDecorator(circle));
        Shape fancyRect = new ShadowDecorator(rect);

        // Клонування
        Shape clonedCircle = fancyCircle.clone();

        // Колекція фігур
        ShapeCollection canvas = new ShapeCollection();
        canvas.addShape(fancyCircle);
        canvas.addShape(fancyRect);
        canvas.addShape(clonedCircle);

        // Iterator
        System.out.println("Drawing all shapes on canvas:");
        for (Shape shape : canvas) {
            shape.draw();
            System.out.println("---");
        }
    }
}
