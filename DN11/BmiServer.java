/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bmi;

import javax.xml.ws.Endpoint;

public class BmiServer {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String endpointUrl = "http://localhost:8081/bmi/BmiServer";
        Object service = new bmi.BmiService();
        Endpoint endpoint = Endpoint.publish(endpointUrl, service);
        System.out.println("WebServer started on " + endpointUrl);
        try {
            Thread.sleep(Long.MAX_VALUE);
        } catch (Exception e) {
        };
        System.out.println("WebServer stop");
    }

}