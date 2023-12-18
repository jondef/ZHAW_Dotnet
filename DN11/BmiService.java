package bmi;

import javax.swing.JOptionPane;
import javax.xml.ws.Endpoint;
import javax.jws.*;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public class BmiService {

    @WebMethod
    public double bmi(@WebParam(name = "weight") double w, @WebParam(name = "height") double h) {
        System.out.println("bmi Service called with " + w + " " + h);
        return w / (h * h);
    }
}