function [] = plotParticipantJointsAverage(time_average_table)
% 
% Per participant
% 

joints_util;

title_format = 'Joints Average: [Participant: %d; KinectConfig: %d; ScenarioId: %d]';
dir = 'Plots/Joints_Average/';
filename_format = strcat(dir,'Joints_Average_Participant_%d_KinectConfig_%d_ScenarioId_%d');

first_avg_dx = 5;
first_avg_dy = 7;
first_avg_dz = 9;
first_avg_dd = 11;
last_idx = 4+length(joint_types)*8;

for participant_id = unique(time_average_table.Study_Id,'rows').'
    s_table = time_average_table(time_average_table.Study_Id==participant_id,:);
    
    for kinect_config = unique(s_table.Kinect_Config,'rows').'
        k_table = s_table(s_table.Kinect_Config==kinect_config,:);
        
        for scenario_id = unique(k_table.Scenario_Id,'rows').'
            scen_table = k_table(k_table.Scenario_Id==scenario_id,:);

			x = (1:length(joint_types))';
            % Assume one row (one person)
            avg_dx = scen_table{1,first_avg_dx:8:last_idx}.';
			std_dx = scen_table{1,first_avg_dx+1:8:last_idx}.';
			avg_dy = scen_table{1,first_avg_dy:8:last_idx}.';
			std_dy = scen_table{1,first_avg_dy+1:8:last_idx}.';
			avg_dz = scen_table{1,first_avg_dz:8:last_idx}.';
			std_dz = scen_table{1,first_avg_dz+1:8:last_idx}.';
			avg_dd = scen_table{1,first_avg_dd:8:last_idx}.';
			std_dd = scen_table{1,first_avg_dd+1:8:last_idx}.';
            
			figure;
			hold on;
			errorbar(x,avg_dx,std_dx,'-r','LineStyle','none','Marker','x');
			errorbar(x,avg_dy,std_dy,'-g','LineStyle','none','Marker','x');
			errorbar(x,avg_dz,std_dz,'-b','LineStyle','none','Marker','x');
			errorbar(x,avg_dd,std_dd,'-k','LineStyle','none','Marker','o','MarkerSize',12);
            box on;
			hold off;

			plot_title = sprintf(title_format, participant_id, kinect_config, scenario_id);
			plot_filename = sprintf(filename_format, participant_id, kinect_config, scenario_id);

			title(plot_title,'Fontsize',15);
			xlabel({'','','','','Joint Types',''},'Fontsize',15);
			ylabel('Distance (cm)','Fontsize',15);
            set(gca,'XLim',[0.5 length(joint_types)+0.5]);
			set(gca,'XTick',1:length(joint_types),'XTickLabel',joint_types);
			rotateticklabel(gca, -90);
			legend('\Delta x','\Delta y','\Delta z','\Delta d','Location','northwest');
            
%             xh = get(gca,'XLabel');
%             set(xh,'Units','Normalized');
%             set(xh,'Position',get(xh,'Position')-[0 0.1 0]);
            
            set(gcf,'Visible','Off');
			set(gcf,'PaperPositionMode','Manual');
			set(gcf,'PaperUnits','Normalized');
% 			set(gcf,'PaperPosition', [0 0 1 0.6])
			print('-dsvg','-painters',plot_filename);
		end
	end
end

end