jsPlumb.ready(function () {

    var instance = jsPlumb.getInstance({
        // default drag options
        DragOptions: { cursor: 'pointer', zIndex: 2000 },
        // the overlays to decorate each connection with.  note that the label overlay uses a function to generate the label text; in this
        // case it returns the 'labelText' member that we set on each connection in the 'init' method below.
        ConnectionOverlays: [
			["Arrow", { location: 1 }],
			["Label", {
			    location: 0.1,
			    id: "label"
			    //cssClass:"aLabel"    //�������ߵ�С��ҵ����Ҫȥ��
			}]
        ],
        Container: "flowchart-demo"
    });


    //$("#flowchartWindow1").css("background-color", "blue");

    // ���ߵ���ʽ
    var connectorPaintStyle = {
        lineWidth: 1,
        strokeStyle: "#61B7CF",
        joinstyle: "round",
        outlineColor: "white",
        outlineWidth: 2
    },
	// ���ŵ������ϵ���ʽ
	connectorHoverStyle = {
	    lineWidth: 1,
	    strokeStyle: "#216477",
	    outlineWidth: 2,
	    outlineColor: "white"
	},

	endpointHoverStyle = {
	    fillStyle: "#216477",
	    strokeStyle: "#216477"
	},

	// the definition of source endpoints (the small blue ones)
	sourceEndpoint = {
	    endpoint:"Dot",
	    paintStyle: {
	        strokeStyle: "#7AB02C",
	        fillStyle: "transparent",
	        radius: 1,//radius-�������ӵ�Բ�Ĵ�С
	        lineWidth: 1
	    },
	    isSource: true,
	    //gap: 0��ָ����ͷ�ļ�࣬������
	    connector: ["Flowchart", { stub: [40, 60], gap: 0, cornerRadius: 5, alwaysRespectStubs: true }],
	    connectorStyle: connectorPaintStyle,
	    hoverPaintStyle: endpointHoverStyle,
	    connectorHoverStyle: connectorHoverStyle,
	    dragOptions: {},
	    overlays:[
	    	[ "Label", { 
	        	//location:[0.5, 1.5], 
	        	//label:"Drag",
	        	//cssClass:"endpointSourceLabel" 
	        } ]
	    ]
	},
	// the definition of target endpoints (will appear when the user drags a connection) 
	targetEndpoint = {
	    endpoint:"Dot",					
	    paintStyle: { fillStyle: "#7AB02C", radius: 1 },//�������ӵ�Բ�Ĵ�С
	    hoverPaintStyle: endpointHoverStyle,
	    maxConnections: -1,
	    dropOptions: {
	        hoverClass: "hover",
	        activeClass: "active"
	    },
	    isTarget:true,			
	    overlays:[
	    	["Label", {
	    	    //location: [0.5, -0.5],
	    	    //label: "Drop",
	    	    //cssClass: "endpointTargetLabel"
	    	}]
	    ]
	},
	init = function (connection) {
	    //connection.getOverlay("label").setLabel(connection.sourceId.substring(15) + "-" + connection.targetId.substring(15));
	    //connection.bind("editCompleted", function(o) {
	    //	if (typeof console != "undefined")
	    //		console.log("connection edited. path is now ", o.path);
	    //});
	};

    var _addEndpoints = function (toId, sourceAnchors, targetAnchors) {
        for (var i = 0; i < sourceAnchors.length; i++) {
            var sourceUUID = toId + sourceAnchors[i];
            instance.addEndpoint("flowchart" + toId, sourceEndpoint, { anchor: sourceAnchors[i], uuid: sourceUUID });
        }
        for (var j = 0; j < targetAnchors.length; j++) {
            var targetUUID = toId + targetAnchors[j];
            instance.addEndpoint("flowchart" + toId, targetEndpoint, { anchor: targetAnchors[j], uuid: targetUUID });
        }
    };

    // suspend drawing and initialise.
    instance.doWhileSuspended(function () {

      

        //��ָ����ÿ������������¼���ǰ����ǿ�ʼ�ڵ� ������ǱպϽڵ㣩

        _addEndpoints("Window1", ["RightMiddle"], []);
        _addEndpoints("Window2", ["TopCenter", "BottomCenter"], ["LeftMiddle"]);
        _addEndpoints("Window3", ["RightMiddle"], ["LeftMiddle", "BottomCenter"]);
        _addEndpoints("Window4", ["RightMiddle", "TopCenter"], ["LeftMiddle"]);
        _addEndpoints("Window5", ["RightMiddle", "BottomCenter"], ["LeftMiddle"]);
        _addEndpoints("Window6", ["RightMiddle", "TopCenter"], ["LeftMiddle", "BottomCenter"]);
        _addEndpoints("Window7", ["RightMiddle"], ["TopCenter"]);
        _addEndpoints("Window8", ["RightMiddle", "BottomCenter"], ["LeftMiddle"]);


        _addEndpoints("Window9", ["BottomCenter"], ["TopCenter"]);
        _addEndpoints("Window10", ["BottomCenter"], ["TopCenter"]);
        _addEndpoints("Window11", ["BottomCenter"], ["TopCenter", "RightMiddle"]);
        _addEndpoints("Window12", ["RightMiddle"], ["TopCenter"]);
        _addEndpoints("Window13", ["BottomCenter"], ["LeftMiddle"]);
        _addEndpoints("Window14", ["BottomCenter", "LeftMiddle"], ["TopCenter"]);

        _addEndpoints("Window15", ["BottomCenter"], ["TopCenter", "LeftMiddle"]);

        _addEndpoints("Window16", [], ["TopCenter"]);
        // listen for new connections; initialise them the same way we initialise the connections at startup.
        instance.bind("connection", function (connInfo, originalEvent) {
            init(connInfo.connection);
        });

        //��ʼ��ÿ��window�����϶�
        //instance.draggable(jsPlumb.getSelector(".flowchart-demo .window"), { grid: [20, 20] });		
        // THIS DEMO ONLY USES getSelector FOR CONVENIENCE. Use your library's appropriate selector 
        // method, or document.querySelectorAll:
        //jsPlumb.draggable(document.querySelectorAll(".window"), { grid: [20, 20] });

        // ָ��ÿ����ľ���λ�ÿ�������
        instance.connect({ uuids: ["Window1RightMiddle", "Window2LeftMiddle"], editable: true });//���մ����ݵ��� ���ӵ� ����ؽ����
        instance.connect({ uuids: ["Window2TopCenter", "Window3LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window2BottomCenter", "Window4LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window4TopCenter", "Window3BottomCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window4RightMiddle", "Window5LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window5RightMiddle", "Window6LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window3RightMiddle", "Window6LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window5BottomCenter", "Window7TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window7RightMiddle", "Window6BottomCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window6TopCenter", "Window8LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window8BottomCenter", "Window9TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window9BottomCenter", "Window10TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window10BottomCenter", "Window11TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window11BottomCenter", "Window12TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window8RightMiddle", "Window13LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window13BottomCenter", "Window14TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���
        instance.connect({ uuids: ["Window14LeftMiddle", "Window11RightMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window14BottomCenter", "Window15TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        instance.connect({ uuids: ["Window12RightMiddle", "Window15LeftMiddle"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���


        instance.connect({ uuids: ["Window15BottomCenter", "Window16TopCenter"], editable: true });//��window2�ĵײ����ӵ�window3�Ķ���

        // ������߿���ɾ������
        //instance.bind("click", function (conn, originalEvent) {
        //    if (confirm("Delete connection from " + conn.sourceId + " to " + conn.targetId + "?"))
        //        jsPlumb.detach(conn);
        //});

        //д�������϶���־
        //instance.bind("connectionDrag", function (connection) {
        //    console.log("connection " + connection.id + " is being dragged. suspendedElement is ", connection.suspendedElement, " of type ", connection.suspendedElementType);
        //});

        //д�������϶�ֹͣ��־
        //instance.bind("connectionDragStop", function (connection) {
        //    console.log("connection " + connection.id + " was dragged");
        //});

        //instance.bind("connectionMoved", function (params) {
        //    console.log("connection " + params.connection.id + " was moved");
        //});
    });

    jsPlumb.fire("jsPlumbDemoLoaded", instance);

});